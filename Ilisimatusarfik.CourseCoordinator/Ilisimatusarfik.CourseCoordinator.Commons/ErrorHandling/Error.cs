namespace Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling
{
    using System.Net;

    public readonly struct Error
    {
        public Error(HttpStatusCode status, string message)
        {
            Status = status;
            Message = message;
        }

        public Error(int status, string message)
        {
            Status = (HttpStatusCode)status;
            Message = message;
        }

        public HttpStatusCode Status { get; }
        public string Message { get; }
    }
}