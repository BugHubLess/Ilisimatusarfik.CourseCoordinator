namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Places
{
    using System;
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;

    public class Lecture : IComparable<Lecture>
    {
        int LectureID { get; set; }
        Course Course { get; set; }
        DateTimeOffset Start { get; set; }
        TimeSpan Duration { get; set; }
        Status Status { get; set; }
        Classroom Classroom { get; set; }

        public int CompareTo(Lecture other)
        {
            // If this start is older than
            // the other one, we return -1
            return Start.CompareTo(other.Start);
        }
    }
}
