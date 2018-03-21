namespace Ilisimatusarfik.CourseCoordinator.Commons.Actions
{
    public interface IRollCall
    {
        int StudentID { get; set; }
        int LectureID { get; set; }
        bool? IsPresent { get; set; }
    }
}
