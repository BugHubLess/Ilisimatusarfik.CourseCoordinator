namespace Ilisimatusarfik.CourseCoordinator.Commons.Materials
{
    using System.Collections.Generic;

    public interface ISyllabus
    {
        int CourseID { get; set; }
        IList<IResource> Materials { get; set; }
    }
}
