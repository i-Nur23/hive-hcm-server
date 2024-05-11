using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MoodService.Domain.Entities;

namespace MoodService.Application.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        public DbSet<Employee> Employees { get; }

        public DbSet<Assessment> Assessments { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        public Task MigrateDatabaseAsync(CancellationToken cancellationToken = default);

        public DatabaseFacade Database { get; }
    }
}
