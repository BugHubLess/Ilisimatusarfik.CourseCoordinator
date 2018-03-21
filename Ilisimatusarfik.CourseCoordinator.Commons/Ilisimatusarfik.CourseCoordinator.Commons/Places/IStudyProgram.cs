namespace Ilisimatusarfik.CourseCoordinator.Commons.Places
{
    using System.Collections.Generic;

    public interface IStudyProgram
    {
        int StudyProgramID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IList<ISemester> SemesterCourses { get; set; }
    }
}
