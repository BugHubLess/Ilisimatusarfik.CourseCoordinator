namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Places
{
    using System;
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;

    public class Lecture : IComparable<Lecture>
    {
        public int LectureID { get; set; }
        public Course Course { get; set; }
        public DateTimeOffset Start { get; set; }
        public TimeSpan Duration { get; set; }
        public Status Status { get; set; }
        public Classroom Classroom { get; set; }

        public int CompareTo(Lecture other)
        {
            // If this start is older than
            // the other one, we return -1
            return Start.CompareTo(other.Start);
        }

        public bool ScheduleConflict(Lecture other)
        {
            var end = Start.Add(Duration);
            var otherEnd = other.Start.Add(other.Duration);

            if (other.Start == Start) return true;

            var s1 = (Start < other.Start && other.Start < end);
            var s2 = (Start < otherEnd && otherEnd < end);
            var s3 = (other.Start < Start && Start < otherEnd);

            return s1 || s2 || s3;
        }
    }
}
