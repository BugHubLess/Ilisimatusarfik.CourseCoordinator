namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Collections
{
    public class Page<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public T Items { get; set; }
    }
}
