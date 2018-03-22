namespace Ilisimatusarfik.CourseCoordinator.Tests.Models.LectureTests
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using System;
    using Xunit;

    public class ScheduleConflictMethodTests
    {
        [Theory]
        [InlineData(10, 0, 2, 12, 0, 1)]
        [InlineData(9, 59, 2, 11, 59, 1)]
        public void WhenNotOverlapping_ShouldNotHaveScheduleConflict(int hour1, int minutes1, int duration1, int hour2, int minutes2, int duration2)
        {
            // Arrange
            var l1 = new Lecture();
            var l2 = new Lecture();

            l1.Start = new DateTimeOffset(2018, 3, 22, hour1, minutes1, 0, TimeSpan.FromHours(-3));
            l1.Duration = TimeSpan.FromHours(duration1);

            l2.Start = new DateTimeOffset(2018, 3, 22, hour2, minutes2, 0, TimeSpan.FromHours(-3));
            l2.Duration = TimeSpan.FromHours(duration2);

            // Act
            var hasConflict = l1.ScheduleConflict(l2);

            // Assert
            Assert.False(hasConflict);
        }
    }
}
