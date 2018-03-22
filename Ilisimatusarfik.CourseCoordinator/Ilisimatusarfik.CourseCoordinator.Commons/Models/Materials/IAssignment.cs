namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using System;

    public interface IAssignment
    {
        int AssignmentID { get; set; }
        string Description { get; set; }
        ICourse Course { get; set; }
        DateTimeOffset DueDate { get; set; }
        bool IsMandatory { get; set; }
    }
}
