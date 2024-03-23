using UserService.Models.Entities;

namespace UserService.Persistance.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);

        public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task AddAsync(User user, CancellationToken cancellationToken);

        public Task UpdateAsync(User user, CancellationToken cancellationToken);
    }
}
