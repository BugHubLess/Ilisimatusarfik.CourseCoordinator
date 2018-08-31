namespace Ilisimatusarfik.CourseCoordinator.Tests.DatabaseIntegration.LectureStatusRepository.Create
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using Ilisimatusarfik.CourseCoordinator.DAL.Factories;
    using Ilisimatusarfik.CourseCoordinator.DAL.Repositories;
    using System.Threading.Tasks;
    using Xunit;

    public class CreateLectureStatusTests
    {
        private const string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Ilisimatusarfik.Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [Theory]
        [InlineData("kl-GL", 1, "Kalaallisut", "Pisussamisoorpoq")]
        [InlineData("da-DK", 2, "Dansk", "Planlagt")]
        [Trait("DatabaseIntegration", "Success")]
        public async void WhenLocaleExists_ShouldCreateLectureStatus(string locale, int languageId, string displayName, string localeStatus)
        {
            // Arrange
            ILectureStatusRepository lectureStatusRepository = new LectureStatusRepository(new ConnectionFactory(connectionString));
            var status = new LectureStatus
            {
                Language = new Language
                {
                    DisplayName = displayName,
                    LanguageID = languageId,
                    Locale = locale
                },
                LectureStatusID = 0,
                Status = localeStatus
            };
            int id = 0;

            // Act
            var created = await lectureStatusRepository.CreateStatus(status);
            var result = created.Match(
                success: l => { id = l.LectureStatusID; return true; },
                failure: _ => false
            );

            await TearDown(lectureStatusRepository, id);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Kalaallisut", "Pisussamisoorpoq")]
        [InlineData("Dansk", "Planlagt")]
        [Trait("DatabaseIntegration", "Failure")]
        public async void WhenLocaleDoesNotExist_ShouldNotCreateStatus(string displayName, string localeStatus)
        {
            // Arrange
            ILectureStatusRepository lectureStatusRepository = new LectureStatusRepository(new ConnectionFactory(connectionString));
            var status = new LectureStatus
            {
                Language = new Language
                {
                    DisplayName = displayName,
                    LanguageID = 1,
                    Locale = ""
                },
                LectureStatusID = 0,
                Status = localeStatus
            };
            int id = 0;

            // Act
            var created = await lectureStatusRepository.CreateStatus(status);
            var result = created.Match(
                success: l => { id = l.LectureStatusID; return true; },
                failure: _ => false
            );

            if(result)
            {
                await TearDown(lectureStatusRepository, id);
            }

            // Assert
            Assert.False(result);
        }

        private async Task TearDown(ILectureStatusRepository lectureStatusRepository, int id)
        {
            if (id <= 0) return;
            var deleted = await lectureStatusRepository.DeleteStatus(id);
            return;
        }
    }
}