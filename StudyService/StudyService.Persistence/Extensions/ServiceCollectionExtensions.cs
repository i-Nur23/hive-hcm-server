using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyService.Persistence.Repositories;
using StudyService.Persistence.Repositories.Interfaces;

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

            services.AddScoped<DatabaseManager>();

            services.RegisterRepositories();

            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<ICoursesRepository, CoursesRepository>();

            return services;
        }
    }
}
