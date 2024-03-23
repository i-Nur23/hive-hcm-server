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
            CancellationToken cancellationToken = default)
        {
            if (condition is null)
            {
                return null;
            }

            return await _dbContext.Employees
                .Include(e => e.Country)
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
    }
}
