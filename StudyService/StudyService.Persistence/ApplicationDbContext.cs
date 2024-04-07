using Microsoft.EntityFrameworkCore;
using StudyService.Models.Entities;

namespace StudyService.Persistence
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeCourse> EmployeeCourses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Courses)
                .WithMany(c => c.Employees)
                .UsingEntity<EmployeeCourse>(
                    j => j
                        .HasOne(ec => ec.Course)
                        .WithMany(c => c.EmployeeCourses)
                        .HasForeignKey(ec => ec.CourseId),
                    j => j
                        .HasOne(ec => ec.Employee)
                        .WithMany(e => e.EmployeeCourses)
                        .HasForeignKey(ec => ec.EmployeeId),
                    j =>
                    {
                        j.HasKey(t => new { t.CourseId, t.EmployeeId });
                    }
                );

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.IntitiatedCourses)
                .WithOne(c => c.Initiator);

            modelBuilder.Entity<Employee>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }

        public async Task MigrateDatabaseAsync(CancellationToken cancellationToken = default)
        {
           await Database.MigrateAsync(cancellationToken);   
        }
    }
}
