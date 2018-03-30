namespace Ilisimatusarfik.CourseCoordinator.DAL.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Transactions;
    using Dapper;
    using System.Data;
    using System.Net;

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
                var sqlParams = new
                {
                    name = status.Name,
                    locale = locale
                };

                var id = await connection.ExecuteScalarAsync<int>("SPCreateStatusTranslation", sqlParams, commandType: CommandType.StoredProcedure);
                if(id > 0)
                {
                    transactionScope.Complete();
                    status.StatusID = id;
                    return Builder.CreateSuccess(status);
                }

                var error = new Error((int)HttpStatusCode.InternalServerError, "Could not create status");
                return Builder.CreateError(status, error);
            }
        }

        public Task<Result> DeleteStatus(int statusId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Status>>> GetAllStatus(Status status, string locale)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Status>> GetStatus(int statusId, string locale)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> TranslateStatus(Status status, string locale)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    statusId = status.StatusID,
                    locale = locale,
                    name = status.Name
                };

                var result = await connection.ExecuteAsync("SPUpdateOrAddStatusTranslation", sqlParams, commandType: CommandType.StoredProcedure);
                if(result == 1)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                var error = new Error(HttpStatusCode.InternalServerError, $"Could not update or create a translation for status with ID: {status.StatusID}");
                return Builder.CreateError(error);
            }
        }
    }
}
