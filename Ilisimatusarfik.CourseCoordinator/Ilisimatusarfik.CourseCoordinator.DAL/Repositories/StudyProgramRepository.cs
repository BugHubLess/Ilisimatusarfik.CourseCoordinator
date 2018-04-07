using System;
using System.Data;
using System.Net;

namespace Ilisimatusarfik.CourseCoordinator.DAL.Repositories
{
    using Dapper;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Transactions;

    public class StudyProgramRepository : IStudyProgramRepository
    {
        private readonly IConnectionFactory connectionFactory;

        public StudyProgramRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<Result> AddCourseToProgram(int studyProgramId, Course course, int semester, string locale)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    studyProgramId = studyProgramId,
                    locale = locale,
                    courseId = course.CourseID,
                    startDate = course.StartDate,
                    endDate = course.EndDate,
                    name = course.Name,
                    description = course.Description,
                    ects = course.ECTS,
                    semester = semester
                };

                var result = await connection.ExecuteAsync("SPAddOrUpdateCourseToStudyProgram", sqlParams, commandType: CommandType.StoredProcedure);
                if(result > 0)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                const string message = "Could not add the new/existing course to the study program";
                var error = new Error(HttpStatusCode.InternalServerError, message);
                return Builder.CreateError(error);
            }
        }

        public async Task<Result<StudyProgram>> CreateStudyProgram(StudyProgram studyProgram, string locale)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("locale", locale, DbType.StringFixedLength, ParameterDirection.Input, 50);
                param.Add("name", studyProgram.Name, DbType.String, ParameterDirection.Input);
                param.Add("description", studyProgram.Description, DbType.String, ParameterDirection.Input);
                param.Add("id", DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(sql: "SPAddStudyProgram", param: param, commandType: CommandType.StoredProcedure);
                var id = param.Get<int>("id");

                if (id > 0)
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

                if (rows == 1)
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

                foreach (var studyProgram in query)
                {
                    studyProgram.SemesterCourses = GetSemesters(studyProgram.StudyProgramID, locale);
                }

                IList<StudyProgram> result = query.ToList();
                return Builder.CreateSuccess(result);
            }
        }

        private Lazy<IList<Semester>> GetSemesters(int studyProgramId, string locale)
        {
            var sqlParams = new
            {
                studyProgramId = studyProgramId,
                locale = locale
            };

            using (var connection = connectionFactory.CreateConnection())
            {
                var dbSemesters = connection.Query<int, Course, Semester>("SPGetSemesterCoursesByStudyProgram", param: sqlParams, commandType: CommandType.StoredProcedure,
                    map: (semester, course) =>
                {
                    return new Semester
                    {
                        SemesterTerm = semester,
                        Course = course
                    };
                }, splitOn: "Semester,CourseID");

                return new Lazy<IList<Semester>>(() => dbSemesters.ToList());
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

                if (result != null)
                {
                    result.SemesterCourses = GetSemesters(studyProgramId, locale);
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

                if (rows == 1)
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