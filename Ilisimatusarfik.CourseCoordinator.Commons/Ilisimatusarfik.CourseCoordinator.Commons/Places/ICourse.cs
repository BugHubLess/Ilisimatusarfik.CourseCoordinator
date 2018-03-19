namespace Ilisimatusarfik.CourseCoordinator.Commons.Places
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Users;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A course for a single term
    /// </summary>
    public interface ICourse
    {
        int CourseID { get; set; }
        DateTimeOffset StartDate { get; set; }
        DateTimeOffset EndDate { get; set; }
        int ECTS { get; set; }
        string Name { get; set; }
        string Description { get; set; }


        IList<ILecture> Lectures { get; set; }
        IList<IStudent> Enrolled { get; set; }
    }
}
