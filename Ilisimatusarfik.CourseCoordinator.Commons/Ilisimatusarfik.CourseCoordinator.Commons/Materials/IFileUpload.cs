﻿namespace Ilisimatusarfik.CourseCoordinator.Commons.Materials
{
    /// <summary>
    /// A file, which is uploaded by a user, e.g. a student.
    /// </summary>
    public interface IFileUpload
    {
        int FileUploadID { get; set; }
        string Filename { get; set; }
        string Extension { get; set; }
        string MimeType { get; set; }
        string Path { get; set; }
    }
}
