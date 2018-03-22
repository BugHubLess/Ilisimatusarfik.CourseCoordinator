namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Places
{
    using System;
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;

    public interface ILecture : IComparable<ILecture>
    {
        int LectureID { get; set; }
        ICourse Course { get; set; }
        DateTimeOffset Start { get; set; }
        TimeSpan Duration { get; set; }
        IStatus Status { get; set; }
        IClassroom Classroom { get; set; }
    }
}
