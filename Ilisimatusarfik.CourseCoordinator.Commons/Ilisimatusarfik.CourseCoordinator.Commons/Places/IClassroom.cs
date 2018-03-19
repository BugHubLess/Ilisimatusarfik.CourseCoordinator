namespace Ilisimatusarfik.CourseCoordinator.Commons.Places
{
    public interface IClassroom
    {
        int ClassroomID { get; set; }
        int Capacity { get; set; }
        string Location { get; set; }
    }
}
