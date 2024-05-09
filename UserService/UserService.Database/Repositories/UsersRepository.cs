using Microsoft.EntityFrameworkCore;
using UserService.Models.Entities;
using UserService.Persistance.Interfaces;
using UserService.Persistance.Repositories.Interfaces;

namespace UserService.Persistance.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IUserServiceDbContext _dbContext;

        public UsersRepository(IUserServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(
            Guid userId, 
            CancellationToken cancellationToken)
        {
            User user = new User
            {
                Id = userId,
            };

            _dbContext.Users.Attach(user);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return 
                await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return
                await _dbContext.Users.FirstOrDefaultAsync(user => user.Id.Equals(id));
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _dbContext.Users.Update(user);

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

        }
    }
}
