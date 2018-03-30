namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    public interface IStatusRepository
    {
        /// <summary>
        /// New status, with a translation provided.
        /// </summary>
        /// <param name="status">The translation status</param>
        /// <param name="culture">The language</param>
        /// <returns>A result of the created status</returns>
        Task<Result<Status>> CreateStatus(Status status, CultureInfo culture);

        /// <summary>
        /// Updates an existing translation or inserts a new translation
        /// for an existing status.
        /// </summary>
        /// <param name="status">The translation status must exist</param>
        /// <param name="culture">The language must exist</param>
        /// <returns>A result of the translated status</returns>
        Task<Result<Status>> TranslateStatus(Status status, CultureInfo culture);

        Task<Result<IList<Status>>> GetAllStatus(Status status, CultureInfo culture);

        Task<Result<Status>> GetStatus(int statusId, CultureInfo culture);

        Task<Result> DeleteStatus(int statusId);
    }
}