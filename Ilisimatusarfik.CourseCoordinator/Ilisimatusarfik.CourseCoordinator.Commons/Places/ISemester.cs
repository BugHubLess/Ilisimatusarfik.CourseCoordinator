namespace Ilisimatusarfik.CourseCoordinator.Commons.Places
{
    public interface ISemester
    {
        int Semester { get; set; }
        ICourse Course { get; set; }
    }
}
