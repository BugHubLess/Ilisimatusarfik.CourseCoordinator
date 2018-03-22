﻿namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Materials
{
    /// <summary>
    /// A file, which is declared in a syllabus
    /// </summary>
    public class FileResource : Resource
    {
        string Filename { get; set; }
        string Extension { get; set; }
        string MimeType { get; set; }
        string Path { get; set; }
    }
}