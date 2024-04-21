using Microsoft.Extensions.DependencyInjection;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Application.Services;
using System.Reflection;

namespace RecruitmentService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IDivisionsService, DivisionsService>();

            return services;
        }
    }
}
