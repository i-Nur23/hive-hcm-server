using Microsoft.EntityFrameworkCore;
using StudyService.Models.Entities;

namespace StudyService.Persistence
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<CompanyCompetence> CompanyCompetences { get; set; }

        public DbSet<Competence> Competences { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeCompetence> EmployeeCompetences { get; set; }

        public DbSet<EmployeeCourse> EmployeeCourses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
