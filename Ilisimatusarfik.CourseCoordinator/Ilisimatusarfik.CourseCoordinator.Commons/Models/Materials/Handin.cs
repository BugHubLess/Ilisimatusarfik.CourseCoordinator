namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Users;

    public class Handin
    {
        Student Student { get; set; }
        Assignment Assignment { get; set; }
        FileUpload File { get; set; }
    }
}
