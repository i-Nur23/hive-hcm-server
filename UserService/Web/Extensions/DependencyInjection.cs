using UserService.Persistance.Repositories;
using UserService.Persistance.Repositories.Interfaces;
using UserService.Services;
using UserService.Services.Interfaces;
using UserService.Web.BackgroundServices;

namespace UserService.Web.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseMigrateService>();

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
