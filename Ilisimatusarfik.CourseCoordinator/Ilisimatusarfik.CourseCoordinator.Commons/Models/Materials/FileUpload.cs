namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    /// <summary>
    /// A file, which is uploaded by a user, e.g. a student.
    /// </summary>
    public class FileUpload
    {
        public int FileUploadID { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }
    }
}