namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using System;

    public class Resource
    {
        public int ResourceID { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Description { get; set; }
    }
}