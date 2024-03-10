using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Persistance.Interfaces;
using UserService.Persistance.Repositories;
using UserService.Persistance.Repositories.Interfaces;

namespace UserService.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UserServiceDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUserServiceDbContext, UserServiceDbContext>();
            services.AddScoped<IDatabaseRepository, DatabaseRepository>();

            return services;
        } 
    }
}
