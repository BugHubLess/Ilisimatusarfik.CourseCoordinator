namespace Ilisimatusarfik.CourseCoordinator.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using Ilisimatusarfik.CourseCoordinator.WebAPI.Controllers;
    using Ilisimatusarfik.CourseCoordinator.Commons.Repositories;
    using Moq;
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using System.Web.Http.Results;

    public class StudyProgramControllerTests
    {
        [Fact]
        public async void Test()
        {
            // Arrange
            var mock = new Mock<IStudyProgramRepository>(MockBehavior.Strict);
            mock.Setup(x => x.CreateStudyProgram(It.IsAny<StudyProgramInternal>(), It.IsAny<string>())).Returns((StudyProgramInternal study, string locale) =>
            {
                study.StudyProgramID = 1;
                return Task.FromResult<Result<StudyProgramInternal>>(Builder.CreateSuccess(study));
            });
            var repo = mock.Object; 
            var controller = new StudyProgramController(repo);
            var program = new StudyProgram();

            // Act
            var result = await controller.Post("kl-GL", program);
            var content = result as OkNegotiatedContentResult<StudyProgram>;

            // Assert
            Console.WriteLine(content.Content);

        }
    }
}
