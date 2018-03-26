namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    /// <summary>
    /// A file, which is declared in a syllabus
    /// </summary>
    public class FileResource : Resource
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }
    }
}