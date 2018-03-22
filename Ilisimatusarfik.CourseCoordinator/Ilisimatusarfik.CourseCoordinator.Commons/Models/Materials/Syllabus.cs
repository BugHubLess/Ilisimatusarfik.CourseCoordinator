namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using System.Collections.Generic;

    public class Syllabus
    {
        public int CourseID { get; set; }
        public IList<Resource> Materials { get; set; }
    }
}
