namespace Ilisimatusarfik.CourseCoordinator.Commons.Materials
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Users;

    public interface IHandin
    {
        IStudent Student { get; set; }
        IAssignment Assignment { get; set; }
        IFileUpload File { get; set; }
    }
}
