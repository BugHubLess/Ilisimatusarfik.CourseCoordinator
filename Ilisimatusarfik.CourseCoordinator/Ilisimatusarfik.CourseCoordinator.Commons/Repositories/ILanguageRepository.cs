namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using System.Globalization;
    using System.Threading.Tasks;

    public interface ILanguageRepository
    {
        Task<Result<ILanguage>> CreateLanguage(ILanguage language);
        Task<Result<ILanguage>> GetLanguage(CultureInfo culture);
        Task<Result<ILanguage>> GetLanguage(int languageId);
        Task<Result> UpdateLanguage(ILanguage language);
        Task<Result> DeleteLanguage(int languageId);
        Task<Result> DeleteLanguage(CultureInfo culture);
    }
}
