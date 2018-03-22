namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using System.Collections.Generic;

    public class Syllabus
    {
        int CourseID { get; set; }
        IList<Resource> Materials { get; set; }
    }
}
