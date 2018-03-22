namespace Ilisimatusarfik.CourseCoordinator.Tests.Models.LectureTests
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using System;
    using Xunit;

    public class ScheduleConflictMethodTests
    {
        [Fact]
        public void WhenNotOverlapping_ShouldNotHaveScheduleConflict()
        {
            // Arrange
            var l1 = new Lecture();
            var l2 = new Lecture();

            l1.Start = new DateTimeOffset(2018, 3, 22, 10, 0, 0, TimeSpan.FromHours(-3));
            l1.Duration = TimeSpan.FromHours(2);

            l2.Start = new DateTimeOffset(2018, 3, 22, 12, 0, 0, TimeSpan.FromHours(-3));
            l2.Duration = TimeSpan.FromHours(1);

            // Act
            var hasConflict = l1.ScheduleConflict(l2);

            // Assert
            Assert.False(hasConflict);
        }
    }
}
