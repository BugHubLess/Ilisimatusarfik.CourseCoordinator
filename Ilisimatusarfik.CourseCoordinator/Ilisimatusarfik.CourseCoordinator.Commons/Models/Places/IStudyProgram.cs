namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Places
{
    using System.Collections.Generic;

    /// <summary>
    /// A single study program, i.e.
    /// Social sciences, journalism, business economist.
    /// </summary>
    public interface IStudyProgram
    {
        int StudyProgramID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IList<ISemester> SemesterCourses { get; set; }
    }
}
