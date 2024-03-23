using System.Net;

namespace Core.Exceptions
{
    public class ForbiddenException : CustomResponseException
    {
        public override HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Forbidden;
    }
}
