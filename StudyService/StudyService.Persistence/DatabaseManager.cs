namespace StudyService.Persistence
{
    public class DatabaseManager
    {
        private readonly IApplicationDbContext _dbContext;

        public DatabaseManager(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
        }
    }
}
