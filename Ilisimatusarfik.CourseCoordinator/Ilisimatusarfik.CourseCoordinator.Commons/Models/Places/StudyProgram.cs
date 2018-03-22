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
        public int StudyProgramID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Lazy<IList<Semester>> SemesterCourses { get; set; }
    }
}
