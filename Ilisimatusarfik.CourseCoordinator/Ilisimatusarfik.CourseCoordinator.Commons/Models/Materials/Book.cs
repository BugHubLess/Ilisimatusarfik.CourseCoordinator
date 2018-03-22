namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using System;

    public class Book : Resource
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string Edition { get; set; }
        public string ISBN { get; set; }
        public string Subtitle { get; set; }
    }
}
