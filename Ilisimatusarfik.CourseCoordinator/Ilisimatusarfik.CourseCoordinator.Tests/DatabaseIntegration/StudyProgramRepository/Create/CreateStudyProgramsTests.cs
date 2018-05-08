namespace Ilisimatusarfik.CourseCoordinator.Tests.DatabaseIntegration.StudyProgramRepository.Create
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using Ilisimatusarfik.CourseCoordinator.DAL.Factories;
    using System.Threading.Tasks;
    using Xunit;
    using T = DAL.Repositories.StudyProgramRepository;

    public class CreateStudyProgramsTests
    {
        private const string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Ilisimatusarfik.Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [Theory]
        [InlineData("kl-GL", "Suliffeqarfilerineq", "Suliffeqarfimmut tunngatillugu ilinniarneq")]
        [Trait("DatabaseIntegration", "Success")]
        public async void WhenLocaleExists_ShouldCreateStudyProgram(string locale, string name, string description)
        {
            // Arrange
            IStudyProgramRepository repo = new T(new ConnectionFactory(connectionString));
            var studyProgram = new StudyProgramInternal
            {
                Name = name,
                Description = description
            };
            int id = 0;

            // Act
            var created = await repo.CreateStudyProgram(studyProgram, locale);
            var result = created.Match(
                success: s => { id = s.StudyProgramID; return true; },
                failure: _ => false
            );

            await TearDown(repo, id);

            // Assert
            Assert.True(result);
        }

        private async Task TearDown(IStudyProgramRepository studyProgramRepository, int id)
        {
            if (id <= 0) return;
            var deleted = await studyProgramRepository.DeleteStudyProgram(id);
            return;
        }
    }
}
