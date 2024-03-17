
using UserService.Persistance.Interfaces;

namespace UserService.Web.BackgroundServices
{
    public class DatabaseMigrateService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseMigrateService(IServiceProvider provider)
        {
            _serviceProvider = provider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                using (IUserServiceDbContext dbContext = scope.ServiceProvider.GetRequiredService<IUserServiceDbContext>())
                {
                    await dbContext.MigrateDatabaseAsync(cancellationToken);
                }
            }
        }
    }
}
