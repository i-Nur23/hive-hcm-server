using System.Net;

namespace Core.Responses
{
    public class RequestResult
    {
        public bool Ok { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}
