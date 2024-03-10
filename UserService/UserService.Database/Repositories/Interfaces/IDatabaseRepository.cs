namespace UserService.Persistance.Repositories.Interfaces
{
    public interface IDatabaseRepository
    {
        public Task StartTransactionAsync(CancellationToken cancellationToken = default);

        public Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        public Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
