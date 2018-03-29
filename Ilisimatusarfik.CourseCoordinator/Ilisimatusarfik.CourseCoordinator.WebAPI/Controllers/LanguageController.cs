namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Controllers
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class LanguageController : ApiController
    {
        private readonly ILanguageRepository languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            this.languageRepository = languageRepository;
        }

        public async Task<HttpResponseMessage> Get()
        {
            var result = await languageRepository.GetLanguages();
            return result.Match(
                languages => Request.CreateResponse(languages),
                error => Request.CreateErrorResponse((HttpStatusCode)error.Status, error.Message)
            );
        }

        // String format: kl-GL
        // kl = ISO 639-1, languagecode
        // GL = ISO 3166, countrycode
        //  or instead of countrycode
        // language tag BCP-47
        public async Task<HttpResponseMessage> Get(string culture)
        {
            var result = await languageRepository.GetLanguage(new CultureInfo(culture));
            return result.Match(
                language => Request.CreateResponse(language),
                error => Request.CreateErrorResponse((HttpStatusCode)error.Status, error.Message)
            );
        }

        public async Task<HttpResponseMessage> Post(Language language)
        {
            var result = await languageRepository.CreateLanguage(language);
            return result.Match(
                created => Request.CreateResponse(HttpStatusCode.Created, created),
                error => Request.CreateErrorResponse((HttpStatusCode)error.Status, error.Message)
            );
        }

        public async Task<HttpResponseMessage> Put(Language language)
        {
            var result = await languageRepository.UpdateLanguage(language);
            return result.Match(
                () => Request.CreateResponse(HttpStatusCode.NoContent),
                error => Request.CreateErrorResponse((HttpStatusCode)error.Status, error.Message)
            );
        }
    }
}