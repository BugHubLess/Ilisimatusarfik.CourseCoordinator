namespace Ilisimatusarfik.CourseCoordinator.DAL.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
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

        public async Task<Result<Status>> CreateStatus(Status status, CultureInfo culture)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    name = status.Name,
                    culture = culture.ToString()
                };

                var id = await connection.ExecuteAsync("SPCreateStatusTranslation", sqlParams, commandType: CommandType.StoredProcedure);
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

        public Task<Result<IList<Status>>> GetAllStatus(Status status, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Status>> GetStatus(int statusId, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Status>> TranslateStatus(Status status, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
