namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Places
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Users;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A course for a single semester
    /// </summary>
    public class Course
    {
        public int CourseID { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int ECTS { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public Lazy<IList<Lecture>> Lectures { get; set; }
        public Lazy<IList<Student>> Enrolled { get; set; }
    }
}
