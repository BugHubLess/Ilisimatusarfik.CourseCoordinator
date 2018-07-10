namespace Ilisimatusarfik.CourseCoordinator.Commons.Actions
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Users;
    using System;

    public class RequestClassroom
    {
        public int LectureID { get; set; }
        public int ClassroomID { get; set; }
        public Employee Requestor { get; set; }
        public DateTimeOffset RequestedBookingDate { get; set; }
    }
}
