namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Users;

    public interface IHandin
    {
        IStudent Student { get; set; }
        IAssignment Assignment { get; set; }
        IFileUpload File { get; set; }
    }
}
