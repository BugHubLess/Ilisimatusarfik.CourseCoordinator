namespace Ilisimatusarfik.CourseCoordinator.Commons.Categories
{
    using System.Globalization;

    public class Language
    {
        int LanguageID { get; set; }
        CultureInfo Culture { get; set; }
        string DisplayName { get; set; }
    }
}
