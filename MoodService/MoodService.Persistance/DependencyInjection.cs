using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoodService.Application.Interfaces;
using MoodService.Persistance.BackgroundServcies;

namespace MoodService.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddHostedService<DatabaseMigrationService>();

            return services;
        }
    }
}
