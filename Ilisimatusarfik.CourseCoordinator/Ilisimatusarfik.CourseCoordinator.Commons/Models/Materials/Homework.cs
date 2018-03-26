namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;

    public class Homework
    {
        public int HomeworkID { get; set; }
        public string Description { get; set; }
        public Lecture Due { get; set; }
    }
}