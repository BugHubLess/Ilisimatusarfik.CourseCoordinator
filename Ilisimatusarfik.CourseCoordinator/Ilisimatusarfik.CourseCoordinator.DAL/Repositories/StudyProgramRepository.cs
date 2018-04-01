﻿using System.Data;
using System.Net;

namespace Ilisimatusarfik.CourseCoordinator.DAL.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Transactions;
    using Dapper;

    public class StudyProgramRepository : IStudyProgramRepository
    {
        private readonly IConnectionFactory connectionFactory;

        public StudyProgramRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<Result<StudyProgram>> CreateStudyProgram(StudyProgram studyProgram, string locale)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    locale = locale,
                    name = studyProgram.Name,
                    description = studyProgram.Description
                };

                var id = await connection.ExecuteScalarAsync<int>("SPAddStudyProgram", sqlParams, commandType: CommandType.StoredProcedure);

                if(id > 0)
                {
                    transactionScope.Complete();
                    studyProgram.StudyProgramID = id;
                    return Builder.CreateSuccess(studyProgram);
                }

                const string message = "Could not create study program in the database";
                var error = new Error(HttpStatusCode.InternalServerError, message);
                return Builder.CreateError(studyProgram, error);
            }
        }

        public async Task<Result> DeleteStudyProgram(int studyProgramId)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    studyId = studyProgramId
                };

                var rows = await connection.ExecuteAsync("SPDeleteStudyProgram", sqlParams, commandType: CommandType.StoredProcedure);

                if( rows == 1)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                var message = $"Could not delete study program with id: {studyProgramId}";
                var error = new Error(HttpStatusCode.InternalServerError, message);
                return Builder.CreateError(error);
            }
        }

        public async Task<Result<IList<StudyProgram>>> GetAllStudyPrograms(string locale)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    locale = locale
                };

                var query = await connection.QueryAsync<StudyProgram>("SPGetStudyPrograms", sqlParams, commandType: CommandType.StoredProcedure);
                IList<StudyProgram> result = query.ToList();

                return Builder.CreateSuccess(result);
            }
        }

        public async Task<Result<StudyProgram>> GetStudyProgram(int studyProgramId, string locale)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    studyProgramId = studyProgramId,
                    locale = locale
                };

                var result = await connection.QuerySingleOrDefaultAsync<StudyProgram>("SPGetStudyProgram", sqlParams, commandType: CommandType.StoredProcedure);

                if( result != null)
                {
                    return Builder.CreateSuccess(result);
                }

                // Another reason could be internal server error
                var message = $"Could not find study program with id: {studyProgramId}";
                var error = new Error(HttpStatusCode.NotFound, message);
                return Builder.CreateError(result, error);
            }
        }

        public async Task<Result> UpdateOrTranslateStudyProgram(StudyProgram studyProgram, string locale)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    studyProgramId = studyProgram.StudyProgramID,
                    locale = locale,
                    name = studyProgram.Name,
                    description = studyProgram.Description
                };

                var rows = await connection.ExecuteAsync("SPUpdateOrAddStudyProgramTranslation", sqlParams, commandType: CommandType.StoredProcedure);

                if(rows == 1)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                var message = "Could not update or add translation to study program";
                var error = new Error(HttpStatusCode.InternalServerError, message);
                return Builder.CreateError(error);
            }
        }
    }
}