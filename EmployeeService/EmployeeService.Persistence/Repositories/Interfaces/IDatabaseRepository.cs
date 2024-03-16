namespace EmployeeService.Persistence.Repositories.Interfaces
{
    public interface IDatabaseRepository
    {
        public Task BeginTransactionAsync(CancellationToken cancellationToken);

        public Task CommitTransactionAsync(CancellationToken cancellationToken);

        public Task RollbackTransactionAsync(CancellationToken cancellationToken);
    }
}
