namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IStatusRepository
    {
        Task<Result<Status>> CreateNewStatus(Status status, int languageId);
        Task<Result<Status>> CreateNewStatus(Status status, Language language);
        Task<Result<Status>> CreateNewStatus(Status status, CultureInfo culture);

        Task<Result> AddStatusTranslation(Status status, Language language);
        Task<Result> AddStatusTranslation(Status status, CultureInfo culture);

        Task<Result<IList<Status>>> GetAllStatus(Status status, int languageId);
        Task<Result<IList<Status>>> GetAllStatus(Status status, Language language);
        Task<Result<IList<Status>>> GetAllStatus(Status status, CultureInfo culture);

        Task<Result<Status>> GetStatus(int statusId, int languageId);
        Task<Result<Status>> GetStatus(int statusId, Language language);
        Task<Result<Status>> GetStatus(int statusId, CultureInfo culture);

        Task<Result> UpdateStatus(Status status, int languageId);
        Task<Result> UpdateStatus(Status status, Language language);
        Task<Result> UpdateStatus(Status status, CultureInfo culture);

        Task<Result> DeleteStatus(int statusId);
    }
}
