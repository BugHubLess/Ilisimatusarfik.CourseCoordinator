namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    public interface IStatusRepository
    {
        Task<Result<Status>> CreateNewStatus(Status status, CultureInfo culture);

        Task<Result> AddStatusTranslation(Status status, CultureInfo culture);

        Task<Result<IList<Status>>> GetAllStatus(Status status, CultureInfo culture);

        Task<Result<Status>> GetStatus(int statusId, CultureInfo culture);

        Task<Result> UpdateStatus(Status status, CultureInfo culture);

        Task<Result> DeleteStatus(int statusId);
    }
}