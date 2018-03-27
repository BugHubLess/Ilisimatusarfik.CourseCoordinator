namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Controllers
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    }
}
