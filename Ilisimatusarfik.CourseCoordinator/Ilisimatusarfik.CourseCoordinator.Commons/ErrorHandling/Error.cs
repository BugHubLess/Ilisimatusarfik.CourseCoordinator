namespace Ilisimatusarfik.CourseCoordinator.Commons.ErrorHandling
{
    using System.Net;
    using System.Net.Http;

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

        public static implicit operator HttpResponseMessage(Error input)
        {
            var response = new HttpResponseMessage((HttpStatusCode)input.Status)
            {
                ReasonPhrase = input.Message,
                Content = new StringContent(input.Message)
            };
            return response;
        }
    }
}