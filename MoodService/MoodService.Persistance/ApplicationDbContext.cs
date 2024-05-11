using Microsoft.EntityFrameworkCore;
using MoodService.Application.Interfaces;
using MoodService.Domain.Entities;

namespace MoodService.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public async Task MigrateDatabaseAsync(CancellationToken cancellationToken = default)
        {
            await Database.MigrateAsync(cancellationToken);
        }
    }
}