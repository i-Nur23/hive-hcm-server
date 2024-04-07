using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StudyService.Models.Entities;

namespace StudyService.Persistence
{
    public interface IApplicationDbContext : IDisposable
    {
        public DbSet<Course> Courses { get; }

        public DbSet<Employee> Employees { get; }

        public DbSet<EmployeeCourse> EmployeeCourses { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        public Task MigrateDatabaseAsync(CancellationToken cancellationToken = default);

        public DatabaseFacade Database { get; }
    }
}
