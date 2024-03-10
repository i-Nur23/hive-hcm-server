using UserService.Persistance.Interfaces;
using UserService.Persistance.Repositories.Interfaces;

namespace UserService.Persistance.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IUserServiceDbContext _userServiceDbContext;
        public DatabaseRepository
            (IUserServiceDbContext userServiceDbContext)
        {
            _userServiceDbContext = userServiceDbContext;
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _userServiceDbContext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _userServiceDbContext.Database.RollbackTransactionAsync(cancellationToken);
        }

        public async Task StartTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _userServiceDbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
