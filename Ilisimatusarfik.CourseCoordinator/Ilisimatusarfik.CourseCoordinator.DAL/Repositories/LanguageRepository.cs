namespace Ilisimatusarfik.CourseCoordinator.DAL.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Factories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Transactions;
    using Dapper;
    using System.Net;
    using System.Data.SqlClient;

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
            using(var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    culture = language.Culture.ToString(),
                    displayName = language.DisplayName
                };
                var languageId = await connection.ExecuteScalarAsync<int>("SPAddLanguage", sqlParams, commandType: CommandType.StoredProcedure);

                language.LanguageID = languageId;

                if(languageId > 0)
                {
                    transactionScope.Complete();
                    return new Result<Language>.Success(language);
                }
                else
                {
                    var message = "Could not create the language in the database";
                    return new Result<Language>.Error(new Error(HttpStatusCode.InternalServerError, message));
                }
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
                    return new Result.Success();
                }

                var message = "Could not delete the language from the database";
                return new Result.Error(new Error(HttpStatusCode.InternalServerError, message));
            }
        }

        public async Task<Result<Language>> GetLanguage(CultureInfo culture)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                var sqlParams = new
                {
                    culture = culture.ToString()
                };
                var language = await connection.QueryFirstOrDefaultAsync<Language>("SPGetLangauge", sqlParams, commandType: CommandType.StoredProcedure);

                if(language != null)
                {
                    return new Result<Language>.Success(language);
                }

                var error = new Error(HttpStatusCode.NotFound, "Language does not exist in the database");
                return new Result<Language>.Error(error);
            }
        }

        public async Task<Result<IList<Language>>> GetLanguages()
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                try
                {
                    var languages = await connection.QueryAsync<Language>("SPGetAllLanguages", commandType: CommandType.StoredProcedure);
                    return new Result<IList<Language>>.Success(languages.ToList());
                }
                catch (SqlException ex)
                {
                    var error = new Error(HttpStatusCode.InternalServerError, ex.Message);
                    return new Result<IList<Language>>.Error(error);
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
                    culture = language.Culture.ToString(),
                    displayName = language.DisplayName
                };
                var updated = await connection.ExecuteAsync("SPEditLanguage", sqlParams, commandType: CommandType.StoredProcedure);

                if(updated > 0)
                {
                    transactionScope.Complete();
                    return new Result.Success();
                }

                var error = new Error(HttpStatusCode.InternalServerError, "Could not update the language");
                return new Result.Error(error);
            }
        }
    }
}
