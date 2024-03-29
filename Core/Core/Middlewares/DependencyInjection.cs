﻿using Microsoft.AspNetCore.Builder;

namespace Core.Middlewares
{
    public static class DependencyInjection
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CustomExceptionMiddleware>();

            return builder;
        } 
    }
}
