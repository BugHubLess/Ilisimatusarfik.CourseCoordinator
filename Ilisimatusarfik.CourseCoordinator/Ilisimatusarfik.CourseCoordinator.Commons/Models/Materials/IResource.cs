namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using System;

    public interface IResource
    {
        int ResourceID { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        string Description { get; set; }
    }
}
