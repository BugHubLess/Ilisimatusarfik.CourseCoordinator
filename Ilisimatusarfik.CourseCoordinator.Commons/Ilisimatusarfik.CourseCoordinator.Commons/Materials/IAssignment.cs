namespace Ilisimatusarfik.CourseCoordinator.Commons.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Places;
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
