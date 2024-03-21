using EmployeeService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Persistence
{
    public class EmployeeServiceDbContext : DbContext, IEmployeeServiceDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<EmployeeUnit> EmployeeUnits { get; set; }

        public DbSet<Country> Countries { get; set; }

        public EmployeeServiceDbContext(DbContextOptions<EmployeeServiceDbContext> contextOptions)
            : base(contextOptions) { }

        public async Task MigrateDatabaseAsync(CancellationToken cancellationToken = default)
        {
            await Database.MigrateAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Units)
                .WithMany(u => u.Workers)
                .UsingEntity<EmployeeUnit>(
                    j => j
                        .HasOne(eu => eu.Unit)
                        .WithMany(u => u.EmployeeUnits)
                        .HasForeignKey(eu => eu.UnitId),
                    j => j
                        .HasOne(eu => eu.Employee)
                        .WithMany(e => e.EmployeeUnits)
                        .HasForeignKey(eu => eu.EmployeeId),
                    j =>
                    {
                        j.HasKey(t => new { t.UnitId, t.EmployeeId });
                    }
                );

            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Lead)
                .WithMany(e => e.LeadingUnits);
        }
    }
}
