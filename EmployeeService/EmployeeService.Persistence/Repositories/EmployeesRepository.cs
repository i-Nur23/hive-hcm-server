using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeService.Persistence.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IEmployeeServiceDbContext _dbContext;
        public EmployeesRepository(IEmployeeServiceDbContext dbContext)
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

        public async Task<Employee?> GetAsync(
            Expression<Func<Employee, bool>> condition,
            bool isCountryIncluded = true,
            bool isUnitsIncluded = true,
            CancellationToken cancellationToken = default)
        {
            if (condition is null)
            {
                return null;
            }

            IQueryable<Employee> employeesQuery = _dbContext.Employees;

            if (isCountryIncluded)
            {
                employeesQuery = employeesQuery.Include(e => e.Country);
            }

            if (isUnitsIncluded)
            {
                employeesQuery = employeesQuery.Include(e => e.Units);
            }

            return await employeesQuery
                .FirstOrDefaultAsync(
                    condition, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task UpdateAsync(
            Employee employee, 
            CancellationToken cancellationToken = default)
        {
            _dbContext.Employees.Update(employee);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Employee?>> GetAllAsync(
            Expression<Func<Employee, bool>> condition,
            bool isCountryIncluded = true,
            bool isUnitsIncluded = true,
            CancellationToken cancellationToken = default)
        {
            if (condition is null)
            {
                return null;
            }

            IQueryable<Employee> employeesQuery = _dbContext.Employees;

            if (isCountryIncluded)
            {
                employeesQuery = employeesQuery.Include(e => e.Country);
            }

            if (isUnitsIncluded)
            {
                employeesQuery = employeesQuery.Include(e => e.Units);
            }

            return await employeesQuery
                .Where(condition)
                .ToListAsync(cancellationToken);
        }
    }
}
