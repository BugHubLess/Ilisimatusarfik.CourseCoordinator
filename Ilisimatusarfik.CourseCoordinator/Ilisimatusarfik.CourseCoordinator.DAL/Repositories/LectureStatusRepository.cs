namespace Ilisimatusarfik.CourseCoordinator.DAL.Repositories
{
    using Dapper;
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Transactions;
    using IN = StoredProcedures.Input;
    using OUT = StoredProcedures.Output;
    using SP = StoredProcedures.LectureStatusTranslations;

    // TODO: Check the variable names in SQL SP, and the SQL SP name itself
    public class LectureStatusRepository : ILectureStatusRepository
    {
        private readonly IConnectionFactory connectionFactory;

        public LectureStatusRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<Result<LectureStatus>> CreateStatus(LectureStatus status)
        {
            if (status.Language.LanguageID <= 0 || string.IsNullOrEmpty(status.Language.Locale.Trim()))
            {
                var error = new Error(HttpStatusCode.BadRequest, "No locale specified");
                return Builder.CreateError(status, error);
            }

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new DynamicParameters(new IN.Create(status.Status, status.Language.Locale));
                sqlParams.Add(OUT.ID, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteScalarAsync<int>(SP.Create, sqlParams, commandType: CommandType.StoredProcedure);
                var id = sqlParams.Get<int>(OUT.ID);

                if (id > 0)
                {
                    transactionScope.Complete();
                    status.LectureStatusID = id;
                    return Builder.CreateSuccess(status);
                }

                var error = new Error(HttpStatusCode.InternalServerError, "Could not create status for lecture");
                return Builder.CreateError(status, error);
            }
        }

        public async Task<Result> DeleteStatus(int lectureStatusId)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new DynamicParameters(new IN.Delete(lectureStatusId));
                sqlParams.Add(OUT.ROWS, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(SP.Delete, sqlParams, commandType: CommandType.StoredProcedure);
                var rows = sqlParams.Get<int>(OUT.ROWS);

                if (rows == 1)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                var message = $"Could not delete the status for lecture with ID: {lectureStatusId}";
                var error = new Error(HttpStatusCode.InternalServerError, message);
                return Builder.CreateError(error);
            }
        }

        public async Task<Result<IList<LectureStatus>>> GetAllStatus(string locale)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new IN.GetAll(locale);
                var query = await connection.QueryAsync<LectureStatus>(SP.GetMany, sqlParams, commandType: CommandType.StoredProcedure);
                IList<LectureStatus> result = query.ToList();

                return Builder.CreateSuccess(result);
            }
        }

        public async Task<Result<LectureStatus>> GetStatus(int lectureStatusId, string locale)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new IN.GetSingle(lectureStatusId, locale);
                var result = await connection.QueryFirstOrDefaultAsync<LectureStatus>(SP.GetSingle, sqlParams, commandType: CommandType.StoredProcedure);
                return Builder.CreateSuccess(result);
            }
        }

        public async Task<Result> TranslateStatus(LectureStatus lectureStatus)
        {
            if (lectureStatus.Language.LanguageID <= 0 || string.IsNullOrEmpty(lectureStatus.Language.Locale.Trim()))
            {
                var error = new Error(HttpStatusCode.BadRequest, "No locale specified");
                return Builder.CreateError(error);
            }

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new DynamicParameters(new IN.Update(lectureStatus.LectureStatusID, lectureStatus.Language.Locale, lectureStatus.Status));
                sqlParams.Add(OUT.ROWS, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(SP.Update, sqlParams, commandType: CommandType.StoredProcedure);
                var rows = sqlParams.Get<int>(OUT.ROWS);

                if (rows == 1)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                var message = $"Could not update or create a translation for status with ID: {lectureStatus.LectureStatusID}\nPossible reasons:\n1 - The status does not exist\n2 - Unexpected SQL error";
                var error = new Error(HttpStatusCode.InternalServerError, message);
                return Builder.CreateError(error);
            }
        }
    }
}