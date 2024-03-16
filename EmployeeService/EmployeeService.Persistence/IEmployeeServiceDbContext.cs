using EmployeeService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EmployeeService.Persistence
{
    public interface IEmployeeServiceDbContext
    {
        public DbSet<Employee> Employees { get; }

        public DbSet<Company> Companies { get; }

        public DbSet<Unit> Units { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        public DatabaseFacade Database { get; }
    }
}
