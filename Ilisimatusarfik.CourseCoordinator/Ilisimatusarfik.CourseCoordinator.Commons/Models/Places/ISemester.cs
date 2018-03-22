namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Places
{
    public interface ISemester
    {
        int Semester { get; set; }
        ICourse Course { get; set; }
    }
}
