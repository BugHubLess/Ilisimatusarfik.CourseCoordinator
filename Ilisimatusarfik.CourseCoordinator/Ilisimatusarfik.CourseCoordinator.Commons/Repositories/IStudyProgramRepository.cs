namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStudyProgramRepository
    {
        Task<Result<StudyProgram>> CreateStudyProgram(StudyProgram studyProgram, string locale);

        /// <summary>
        /// Get a study program.
        /// Returns error when not found.
        /// </summary>
        /// <param name="studyProgramId">The id of the study program</param>
        /// <param name="locale">The locale of the content of the study program</param>
        /// <returns>A result of a study program or a not found error</returns>
        Task<Result<StudyProgram>> GetStudyProgram(int studyProgramId, string locale);
        Task<Result<IList<StudyProgram>>> GetAllStudyPrograms(string locale);
        Task<Result> AddCourseToProgram(int studyProgramId, Course course, int semester, string locale);
        Task<Result> UpdateOrTranslateStudyProgram(StudyProgram studyProgram, string locale);
        Task<Result> DeleteStudyProgram(int studyProgramId);
    }
}
