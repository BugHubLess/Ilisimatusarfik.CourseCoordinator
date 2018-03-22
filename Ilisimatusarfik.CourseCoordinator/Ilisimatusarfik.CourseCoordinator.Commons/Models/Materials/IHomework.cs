namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;

    public interface IHomework
    {
        int HomeworkID { get; set; }
        string Description { get; set; }
        ILecture Due { get; set; }
    }
}
