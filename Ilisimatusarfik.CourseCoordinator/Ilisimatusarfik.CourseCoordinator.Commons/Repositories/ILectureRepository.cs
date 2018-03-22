namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using Ilisimatusarfik.CourseCoordinator.Commons.Models.Places;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILectureRepository
    {
        Task<IList<Lecture>> GetWeekCourseLectures(int courseId, int weekNumber);
        Task<IList<Lecture>> GetDayCourseLectures(int courseId, DateTimeOffset date);
        Task<IList<Lecture>> GetCourseLectures(int courseId);
        Task<Result<Lecture>> CreateCourseLecture(Lecture lecture);
        Task<Result> UpdateCourseLecture(Lecture lecture);
        Task<Result> DeleteLecture(int lectureId);
    }
}
