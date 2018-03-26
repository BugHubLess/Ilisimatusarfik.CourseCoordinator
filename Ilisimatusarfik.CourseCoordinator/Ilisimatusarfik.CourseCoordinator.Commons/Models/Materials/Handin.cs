namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Users;

    public class Handin
    {
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
        public FileUpload File { get; set; }
    }
}