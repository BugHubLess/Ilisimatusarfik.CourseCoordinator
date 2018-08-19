namespace Ilisimatusarfik.CourseCoordinator.Tests.DatabaseIntegration.LectureStatusRepository.Create
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using Ilisimatusarfik.CourseCoordinator.DAL.Factories;
    using System.Threading.Tasks;
    using Xunit;
    using Ilisimatusarfik.CourseCoordinator.DAL.Repositories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;

    public class CreateLectureStatusTests
    {
        private const string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Ilisimatusarfik.Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [Theory]
        [Trait("DatabaseIntegration", "Success")]
        public async void CreateLectureStatus()
        {
            // Arrange
            ILectureStatusRepository lectureStatusRepository = new LectureStatusRepository(new ConnectionFactory(connectionString));
            var status = new LectureStatus
            {
                Language = new Language
                {
                    DisplayName = "Kalaallisut",
                    LanguageID = 1,
                    Locale = "kl-GL"
                },
                LectureStatusID = 0,
                Status = "Scheduled"
            };

            var result = await lectureStatusRepository.CreateStatus(status, "kl-GL");
        }

        private async Task TearDown(ILectureStatusRepository lectureStatusRepository, int id)
        {
            if (id <= 0) return;
            var deleted = await lectureStatusRepository.DeleteStatus(id);
            return;
        }
    }
}
