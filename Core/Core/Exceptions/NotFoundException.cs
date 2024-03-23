using System.Net;

namespace Core.Exceptions
{
    public class NotFoundException : CustomResponseException
    {
        public override HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;

        public NotFoundException(string message) : base(message) { }
    }
}
