namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStudyProgramRepository
    {
        Task<Result<StudyProgram>> CreateStudyProgram(StudyProgram studyProgram, string locale);
        Task<Result<StudyProgram>> GetStudyProgram(int studyProgramId, string locale);
        Task<Result<IList<StudyProgram>>> GetAllStudyPrograms(string locale);
        Task<Result> UpdateOrTranslateStudyProgram(StudyProgram studyProgram, string locale);
        Task<Result> DeleteStudyProgram(int studyProgramId);
    }
}
