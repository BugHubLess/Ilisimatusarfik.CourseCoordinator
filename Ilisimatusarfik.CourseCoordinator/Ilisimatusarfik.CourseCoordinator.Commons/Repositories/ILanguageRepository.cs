namespace Ilisimatusarfik.CourseCoordinator.Commons.Repositories
{
    using Ilisimatusarfik.CourseCoordinator.Commons.Categories;
    using Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling;
    using System.Globalization;
    using System.Threading.Tasks;

    public interface ILanguageRepository
    {
        Task<Result<Language>> CreateLanguage(Language language);
        Task<Result<Language>> GetLanguage(CultureInfo culture);
        Task<Result<Language>> GetLanguage(int languageId);
        Task<Result> UpdateLanguage(Language language);
        Task<Result> DeleteLanguage(int languageId);
        Task<Result> DeleteLanguage(CultureInfo culture);
    }
}
