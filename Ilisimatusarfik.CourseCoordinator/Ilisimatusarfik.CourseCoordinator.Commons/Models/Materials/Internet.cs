namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using System;

    public class Internet : Resource
    {
        string URL { get; set; }
        DateTimeOffset Date { get; set; }
        string Title { get; set; }
    }
}
