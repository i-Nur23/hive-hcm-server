using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using UserService.Models.Entities;
using UserService.Persistance.Interfaces;

namespace UserService.Persistance
{
    public class UserServiceDbContext : DbContext, IUserServiceDbContext
    {
        public DbSet<User> Users { get; set; }
        DatabaseFacade IUserServiceDbContext.Database { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) 
            : base(options) { }

        public async Task MigrateDatabaseAsync(CancellationToken cancellationToken = default)
        {
            await Database.MigrateAsync(cancellationToken);
        }
    }
}
