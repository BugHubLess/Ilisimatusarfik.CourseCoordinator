namespace Ilisimatusarfik.CourseCoordinator.DAL.Repositories
{
    using Dapper;
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Transactions;
    using SP = StoredProcedures.Languages;

    public class LanguageRepository : ILanguageRepository
    {
        private readonly IConnectionFactory connectionFactory;

        public LanguageRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<Result<Language>> CreateLanguage(Language language)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new DynamicParameters(new
                {
                    locale = language.Locale,
                    displayName = language.DisplayName
                });
                sqlParams.Add("id", DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteScalarAsync<int>(SP.Create, sqlParams, commandType: CommandType.StoredProcedure);

                language.LanguageID = sqlParams.Get<int>("id");
                if (language.LanguageID > 0)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess(language);
                }

                const string message = "Could not create the language in the database";
                var error = new Error(HttpStatusCode.InternalServerError, message);
                return Builder.CreateError(language, error);
            }
        }

        public async Task<Result> DeleteLanguage(int languageId)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    languageId = languageId
                };

                var deleted = await connection.ExecuteAsync(SP.Delete, sqlParams, commandType: CommandType.StoredProcedure);

                if (deleted > 0)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                const string message = "Could not delete the language from the database";
                return new Result.Error(new Error(HttpStatusCode.InternalServerError, message));
            }
        }

        public async Task<Result<Language>> GetLanguage(string locale)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    locale = locale
                };
                var language = await connection.QueryFirstOrDefaultAsync<Language>(SP.Get, sqlParams, commandType: CommandType.StoredProcedure);

                if (language != null)
                {
                    return Builder.CreateSuccess(language);
                }

                var error = new Error(HttpStatusCode.NotFound, "Language does not exist in the database");
                return Builder.CreateError(language, error);
            }
        }

        public async Task<Result<IList<Language>>> GetLanguages()
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                IList<Language> result = null;
                try
                {
                    var languages = await connection.QueryAsync<Language>(SP.GetAll, commandType: CommandType.StoredProcedure);
                    result = languages.ToList();
                    return Builder.CreateSuccess(result);
                }
                catch (SqlException ex)
                {
                    var error = new Error(HttpStatusCode.InternalServerError, ex.Message);
                    return Builder.CreateError(result, error);
                }
            }
        }

        public async Task<Result> UpdateLanguage(Language language)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new DynamicParameters(new
                {
                    languageId = language.LanguageID,
                    locale = language.Locale,
                    displayName = language.DisplayName
                });
                sqlParams.Add("rows", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(SP.Update, sqlParams, commandType: CommandType.StoredProcedure);
                var updated = sqlParams.Get<int>("rows");

                if (updated > 0)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                var error = new Error(HttpStatusCode.InternalServerError, "Could not update the language");
                return new Result.Error(error);
            }
        }
    }
}