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
    using SP = StoredProcedures.StatusTranslations;

    public class StatusRepository : IStatusRepository
    {
        private readonly IConnectionFactory connectionFactory;

        public StatusRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<Result<Status>> CreateStatus(Status status, string locale)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new DynamicParameters(new
                {
                    name = status.Name,
                    locale = locale
                });
                sqlParams.Add("id", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteScalarAsync<int>(SP.Create, sqlParams, commandType: CommandType.StoredProcedure);
                var id = sqlParams.Get<int>("id");

                if (id > 0)
                {
                    transactionScope.Complete();
                    status.StatusID = id;
                    return Builder.CreateSuccess(status);
                }

                var error = new Error((int)HttpStatusCode.InternalServerError, "Could not create status");
                return Builder.CreateError(status, error);
            }
        }

        public async Task<Result> DeleteStatus(int statusId)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new DynamicParameters(new
                {
                    statusId = statusId
                });
                sqlParams.Add("rows", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(SP.Delete, sqlParams, commandType: CommandType.StoredProcedure);
                var rows = sqlParams.Get<int>("rows");

                if (rows == 1)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                var message = $"Could not delete the status with ID: {statusId}";
                var error = new Error(HttpStatusCode.InternalServerError, message);
                return Builder.CreateError(error);
            }
        }

        public async Task<Result<IList<Status>>> GetAllStatus(string locale)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    locale = locale
                };

                var query = await connection.QueryAsync<Status>(SP.GetMany, sqlParams, commandType: CommandType.StoredProcedure);
                IList<Status> result = query.ToList();

                return Builder.CreateSuccess(result);
            }
        }

        public async Task<Result<Status>> GetStatus(int statusId, string locale)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    statusId = statusId,
                    locale = locale
                };

                var result = await connection.QueryFirstOrDefaultAsync<Status>(SP.GetSingle, sqlParams, commandType: CommandType.StoredProcedure);
                return Builder.CreateSuccess(result);
            }
        }

        public async Task<Result> TranslateStatus(Status status, string locale)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new DynamicParameters(new
                {
                    statusId = status.StatusID,
                    locale = locale,
                    name = status.Name
                });
                sqlParams.Add("rows", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(SP.Update, sqlParams, commandType: CommandType.StoredProcedure);
                var rows = sqlParams.Get<int>("rows");

                if (rows == 1)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                var message = $"Could not update or create a translation for status with ID: {status.StatusID}\nPossible reasons:\n1 - The status does not exist\n2 - Unexpected SQL error";
                var error = new Error(HttpStatusCode.InternalServerError, message);
                return Builder.CreateError(error);
            }
        }
    }
}