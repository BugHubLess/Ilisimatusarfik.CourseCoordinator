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
        int CourseID { get; set; }
        DateTimeOffset StartDate { get; set; }
        DateTimeOffset EndDate { get; set; }
        int ECTS { get; set; }
        string Name { get; set; }
        string Description { get; set; }


        Lazy<IList<Lecture>> Lectures { get; set; }
        Lazy<IList<Student>> Enrolled { get; set; }
    }
}
