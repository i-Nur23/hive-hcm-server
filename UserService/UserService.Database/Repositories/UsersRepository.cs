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

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return 
                await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }
    }
}
