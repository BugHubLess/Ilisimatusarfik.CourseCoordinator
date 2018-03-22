namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Places
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A single study program, i.e.
    /// Social sciences, journalism, business economist.
    /// </summary>
    public class StudyProgram
    {
        int StudyProgramID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        Lazy<IList<Semester>> SemesterCourses { get; set; }
    }
}
