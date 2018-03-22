namespace Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling
{
    using System.Net;

    public class Error
    {
        public Error(HttpStatusCode status, string message)
        {
            Status = (int)status;
            Message = message;
        }

        public Error(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public int Status { get; private set; }
        public string Message { get; private set; }
    }
}
