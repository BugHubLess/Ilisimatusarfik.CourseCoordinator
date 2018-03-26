namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using System;

    public class Internet : Resource
    {
        public string URL { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Title { get; set; }
    }
}