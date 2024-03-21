using EmployeeService.Application.Interfaces;
using EmployeeService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<ICountriesService, CountriesService>();  

            return services;
        }
    }
}
