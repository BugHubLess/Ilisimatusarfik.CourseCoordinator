﻿namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILectureStatusRepository
    {
        /// <summary>
        /// New status, with a translation provided.
        /// </summary>
        /// <param name="status">The translation status</param>
        /// <returns>A result of the created status</returns>
        Task<Result<LectureStatus>> CreateStatus(LectureStatus status);

        /// <summary>
        /// Updates an existing translation or inserts a new translation
        /// for an existing status.
        /// Note: that the status text should exist for another language!
        /// </summary>
        /// <param name="status">The translation status must exist</param>
        /// <returns>A result of the translated status</returns>
        Task<Result> TranslateStatus(LectureStatus status);

        /// <summary>
        /// Retrieves all statuses, even those without any actual translations
        /// in the specified locale.
        /// </summary>
        /// <param name="locale">The specified locale</param>
        /// <returns>A full list of statuses</returns>
        Task<Result<IList<LectureStatus>>> GetAllStatus(string locale);

        Task<Result<LectureStatus>> GetStatus(int statusId, string locale);

        Task<Result> DeleteStatus(int statusId);
    }
}