namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILectureRepository
    {
        Task<Result<IList<Lecture>>> GetWeekCourseLectures(int courseId, int weekNumber);
        Task<Result<IList<Lecture>>> GetDayCourseLectures(int courseId, DateTimeOffset date);
        Task<Result<Lecture>> CreateCourseLecture(Lecture lecture);
        Task<Result> UpdateCourseLecture(Lecture lecture);
        Task<Result> DeleteLecture(int lectureId);
    }
}
