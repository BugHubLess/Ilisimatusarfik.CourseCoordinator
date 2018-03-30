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
                var sqlParams = new
                {
                    locale = language.Locale,
                    displayName = language.DisplayName
                };
                var languageId = await connection.ExecuteScalarAsync<int>("SPAddLanguage", sqlParams, commandType: CommandType.StoredProcedure);

                language.LanguageID = languageId;

                if (languageId > 0)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess(language);
                }

                var message = "Could not create the language in the database";
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

                var deleted = await connection.ExecuteAsync("SPDeleteLanguage", sqlParams, commandType: CommandType.StoredProcedure);

                if (deleted > 0)
                {
                    transactionScope.Complete();
                    return Builder.CreateSuccess();
                }

                var message = "Could not delete the language from the database";
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
                var language = await connection.QueryFirstOrDefaultAsync<Language>("SPGetLangauge", sqlParams, commandType: CommandType.StoredProcedure);

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
                    var languages = await connection.QueryAsync<Language>("SPGetAllLanguages", commandType: CommandType.StoredProcedure);
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
                var sqlParams = new
                {
                    languageId = language.LanguageID,
                    locale = language.Locale,
                    displayName = language.DisplayName
                };
                var updated = await connection.ExecuteAsync("SPEditLanguage", sqlParams, commandType: CommandType.StoredProcedure);

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