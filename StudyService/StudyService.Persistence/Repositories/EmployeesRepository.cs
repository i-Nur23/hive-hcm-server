using Microsoft.EntityFrameworkCore;
using StudyService.Models.Entities;
using StudyService.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace StudyService.Persistence.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public EmployeesRepository(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(
            Employee employee, 
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Employees.AddAsync(employee, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Employee>> GetAllAsync(
            Expression<Func<Employee, bool>> condition = null, 
            bool isCoursesIncluded = false, 
            bool isInitiatedCoursesIncluded = false, 
            CancellationToken cancellationToken = default)
        {
            IQueryable<Employee> employeesQuery = _dbContext.Employees;

            if (isCoursesIncluded)
            {
                employeesQuery = employeesQuery.Include(e => e.Courses);
            }

            if (isInitiatedCoursesIncluded)
            {
                employeesQuery = employeesQuery.Include(e => e.IntitiatedCourses);
            }

            if (condition is not null)
            {
                employeesQuery = employeesQuery.Where(condition);
            }

            return await employeesQuery.ToListAsync(cancellationToken);
        }

        public async Task<Employee> GetAsync(
            Expression<Func<Employee, bool>> condition = null, 
            bool isCoursesIncluded = false, 
            bool isInitiatedCoursesIncluded = false,
            CancellationToken cancellationToken = default)
        {
            if (condition is null)
            {
                return null;
            }

            IQueryable<Employee> employeesQuery = _dbContext.Employees;

            if (isCoursesIncluded)
            {
                employeesQuery = employeesQuery
                    .Include(e => e.Courses)
                    .ThenInclude(c => c.Initiator);
            }

            if (isInitiatedCoursesIncluded)
            {
                employeesQuery = employeesQuery
                    .Include(e => e.IntitiatedCourses)
                    .ThenInclude(c => c.Employees);
            }

            return await employeesQuery.FirstOrDefaultAsync(condition, cancellationToken);
        }

        public async Task UpdateAsync(
            Employee employee, 
            CancellationToken cancellationToken = default)
        {
            _dbContext.Employees.Update(employee);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
