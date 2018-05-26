namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Controllers
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using Ilisimatusarfik.CourseCoordinator.WebAPI.Setup;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class StudyProgramController : ApiController
    {
        private readonly IStudyProgramRepository studyProgramRepository;

        public StudyProgramController(IStudyProgramRepository studyProgramRepository)
        {
            this.studyProgramRepository = studyProgramRepository;
        }

        public async Task<IHttpActionResult> Get(int id, string locale, bool courses = false)
        {
            var studyProgram = await studyProgramRepository.GetStudyProgram(id, locale);
            return studyProgram.Match<IHttpActionResult>(
                s =>
                {
                    var study = Convert(s, courses);
                    return Ok(study);
                },
                error => Content(error.Status, error.Message)
            );
        }

        public async Task<IHttpActionResult> Post([FromUri] string locale, [FromBody] StudyProgram studyProgram)
        {
            var created = await studyProgramRepository.CreateStudyProgram(studyProgram, locale);
            return created.Match<IHttpActionResult>(
                c =>
                {
                    var name = ControllerContext.ControllerDescriptor.ControllerName;
                    var parameters = new { controller = name, id = c.StudyProgramID, locale = locale };
                    var location = Url.Route(routeName: Routes.DefaultRouteName, routeValues: parameters);
                    return Created(location, Convert(c, false));
                },
                error => Content(error.Status, error.Message)
            );
        }

        private StudyProgram Convert(StudyProgramInternal input, bool courses)
        {
            var result = new StudyProgram
            {
                Description = input.Description,
                Name = input.Name,
                StudyProgramID = input.StudyProgramID
            };

            result.SemesterCourses = courses ? input.SemesterCourses.Value : null;
            return result;
        }
    }
}