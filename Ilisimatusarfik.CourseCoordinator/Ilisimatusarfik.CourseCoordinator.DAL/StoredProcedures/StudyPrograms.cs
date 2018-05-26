namespace Ilisimatusarfik.CourseCoordinator.DAL.StoredProcedures
{
    public static class StudyPrograms
    {
        internal const string Create = "SPAddStudyProgram";
        internal const string AddCourse = "SPAddOrUpdateCourseToStudyProgram";
        internal const string Delete = "SPDeleteStudyProgram";
        internal const string GetSemester = "SPGetSemesterCoursesByStudyProgram";
        internal const string GetSingle = "SPGetStudyProgram";
        internal const string GetMany = "SPGetStudyPrograms";
        internal const string Translate = "SPUpdateOrAddStudyProgramTranslation";
        internal const string SemesterSplitOn = "Semester,CourseID";
    }
}