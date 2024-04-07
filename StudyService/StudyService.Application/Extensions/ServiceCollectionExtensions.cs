using Microsoft.Extensions.DependencyInjection;
using StudyService.Application.Interfaces;
using StudyService.Application.Services;

namespace StudyService.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices (this IServiceCollection services)
        {
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<ICoursesService, CoursesService>();

            return services;
        }
    }
}
