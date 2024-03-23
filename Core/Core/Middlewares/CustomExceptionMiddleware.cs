using System;
using System.Net;
using Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Core.Middlewares
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
            catch (CustomResponseException exception)
            {
                statusCode = exception.StatusCode; 

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}
