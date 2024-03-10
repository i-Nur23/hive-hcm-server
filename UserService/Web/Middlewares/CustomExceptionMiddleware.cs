using System.Net;
using UserService.Models.Exceptions;

namespace UserService.Web.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            HttpStatusCode statusCode;

            try
            {
                await _next(context);
            }
            catch (BadRequestException exception)
            {
                statusCode = HttpStatusCode.BadRequest; 

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}
