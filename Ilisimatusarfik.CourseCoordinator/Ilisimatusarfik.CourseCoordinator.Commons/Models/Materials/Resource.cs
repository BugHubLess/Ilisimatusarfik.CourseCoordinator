namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using System;

    public class Resource
    {
        int ResourceID { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        string Description { get; set; }
    }
}
