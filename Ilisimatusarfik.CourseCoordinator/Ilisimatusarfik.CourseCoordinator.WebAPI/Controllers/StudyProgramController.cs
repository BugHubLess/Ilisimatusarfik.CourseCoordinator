namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Controllers
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class StudyProgramController : ApiController
    {
        private readonly IStudyProgramRepository studyProgramRepository;

        public StudyProgramController(IStudyProgramRepository studyProgramRepository)
        {
            this.studyProgramRepository = studyProgramRepository;
        }

        public async Task<IHttpActionResult> Get(int id, string locale)
        {
            var studyProgram = await studyProgramRepository.GetStudyProgram(id, locale);
            var result = studyProgram.Match<IHttpActionResult>(
                study => Ok(study),
                error => ResponseMessage(error)
            );

            return result;
        }
    }
}
