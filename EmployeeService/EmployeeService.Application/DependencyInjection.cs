﻿using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}