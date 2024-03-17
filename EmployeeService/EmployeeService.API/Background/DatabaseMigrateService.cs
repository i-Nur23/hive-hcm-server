using EmployeeService.Persistence;

namespace EmployeeService.API.Background
{
    public class DatabaseMigrateService : BackgroundService
    {
        private readonly IServiceProvider _servicesProvider;

        public DatabaseMigrateService(
            IServiceProvider serviceProvider
            )
        {
            _servicesProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            using (IServiceScope scope = _servicesProvider.CreateScope())
            {
                using (IEmployeeServiceDbContext dbContext = scope.ServiceProvider.GetRequiredService<IEmployeeServiceDbContext>())
                {
                    await dbContext.MigrateDatabaseAsync(cancellationToken);
                }
            }
        }
    }
}
