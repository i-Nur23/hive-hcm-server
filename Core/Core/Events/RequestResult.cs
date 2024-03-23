using System.Net;

namespace Core.Events
{
    public class RequestResult
    {
        public bool Ok { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}
