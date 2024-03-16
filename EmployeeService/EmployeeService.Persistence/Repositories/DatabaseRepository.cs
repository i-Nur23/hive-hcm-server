using EmployeeService.Persistence.Repositories.Interfaces;

namespace EmployeeService.Persistence.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IEmployeeServiceDbContext _dbContext;
        public DatabaseRepository(IEmployeeServiceDbContext employeeServiceDbContext)
        {

            _dbContext = employeeServiceDbContext;

        }
        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            await _dbContext.Database.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            await _dbContext.Database.CommitTransactionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            await _dbContext.Database.RollbackTransactionAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
