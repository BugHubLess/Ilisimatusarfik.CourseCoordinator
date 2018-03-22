namespace Ilisimatusarfik.CourseCoordinator.Commons.Categories
{
    using System.Globalization;

    public class Language
    {
        public int LanguageID { get; set; }
        public CultureInfo Culture { get; set; }
        public string DisplayName { get; set; }
    }
}
