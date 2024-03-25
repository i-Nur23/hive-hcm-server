using EmployeeService.Persistence.Repositories;
using EmployeeService.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EmployeeServiceDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IEmployeeServiceDbContext, EmployeeServiceDbContext>();

            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
           
            services.AddScoped<IDatabaseRepository, DatabaseRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IUnitsRepository, UnitsRepository>();

            return services;
        }
    }
}
