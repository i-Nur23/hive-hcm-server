using System.Net;

namespace Core.Exceptions
{
    public class BadRequestException : CustomResponseException
    {
        public override HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;

        public BadRequestException(string message) : base(message) { }
    }
}
