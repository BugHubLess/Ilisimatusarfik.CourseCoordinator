namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using System;

    public class Assignment
    {
        public int AssignmentID { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public bool IsMandatory { get; set; }
    }
}