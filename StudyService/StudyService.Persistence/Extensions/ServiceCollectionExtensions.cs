using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StudyService.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDatabase(
            this IServiceCollection services, 
            IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.RegisterRepositories();

            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {


            return services;
        }
    }
}
