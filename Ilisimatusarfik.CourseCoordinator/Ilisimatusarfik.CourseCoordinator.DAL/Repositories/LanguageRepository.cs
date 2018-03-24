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
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;
    using Dapper;
    using System.Net;

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

        public Task<Result> DeleteLanguage(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Language>> GetLanguage(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<Language>>> GetLanguages()
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateLanguage(Language language)
        {
            throw new NotImplementedException();
        }
    }
}
