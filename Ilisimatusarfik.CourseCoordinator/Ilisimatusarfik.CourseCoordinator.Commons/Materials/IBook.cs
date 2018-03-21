namespace Ilisimatusarfik.CourseCoordinator.Commons.Materials
{
    using System;

    public interface IBook : IResource
    {
        string Title { get; set; }
        string Authors { get; set; }
        int Pages { get; set; }
        string Publisher { get; set; }
        DateTime PublishDate { get; set; }
        string Edition { get; set; }
        string ISBN { get; set; }
        string Subtitle { get; set; }
    }
}
