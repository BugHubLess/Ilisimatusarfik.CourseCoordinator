using System.Net;

namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Controllers
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
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
    }
}
