using System.Net;

namespace Core.Exceptions
{
    public class CustomResponseException : Exception
    {
        public virtual HttpStatusCode StatusCode { get; set; }

        public CustomResponseException(string message = null) : base(message) { }
    }
}
