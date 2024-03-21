using EmployeeService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EmployeeService.Persistence
{
    public interface IEmployeeServiceDbContext : IDisposable
    {
        public DbSet<Employee> Employees { get; }

        public DbSet<Company> Companies { get; }

        public DbSet<Unit> Units { get; }

        public DbSet<EmployeeUnit> EmployeeUnits { get; }

        public DbSet<Country> Countries { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        public Task MigrateDatabaseAsync(CancellationToken cancellationToken = default);

        public DatabaseFacade Database { get; }
    }
}
