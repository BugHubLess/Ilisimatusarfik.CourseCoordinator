namespace Ilisimatusarfik.CourseCoordinator.Commons.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Places;

    public interface IHomework
    {
        int HomeworkID { get; set; }
        string Description { get; set; }
        ILecture Due { get; set; }
    }
}
