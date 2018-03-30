namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStatusRepository
    {
        /// <summary>
        /// New status, with a translation provided.
        /// </summary>
        /// <param name="status">The translation status</param>
        /// <param name="locale">The language</param>
        /// <returns>A result of the created status</returns>
        Task<Result<Status>> CreateStatus(Status status, string locale);

        /// <summary>
        /// Updates an existing translation or inserts a new translation
        /// for an existing status.
        /// Note: that the status text should exist for another language!
        /// </summary>
        /// <param name="status">The translation status must exist</param>
        /// <param name="locale">The language must exist</param>
        /// <returns>A result of the translated status</returns>
        Task<Result> TranslateStatus(Status status, string locale);

        Task<Result<IList<Status>>> GetAllStatus(Status status, string locale);

        Task<Result<Status>> GetStatus(int statusId, string locale);

        Task<Result> DeleteStatus(int statusId);
    }
}