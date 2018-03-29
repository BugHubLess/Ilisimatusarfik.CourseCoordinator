using System.Net;
using System.Globalization;

namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Controllers
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
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
    }
}
