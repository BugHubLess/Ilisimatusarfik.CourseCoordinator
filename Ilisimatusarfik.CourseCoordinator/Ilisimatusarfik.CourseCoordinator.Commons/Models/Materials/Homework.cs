namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;

    public class Homework
    {
        int HomeworkID { get; set; }
        string Description { get; set; }
        Lecture Due { get; set; }
    }
}
