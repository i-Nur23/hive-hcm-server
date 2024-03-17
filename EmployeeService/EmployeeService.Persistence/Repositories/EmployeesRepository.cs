using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            Predicate<Employee> condition, 
            CancellationToken cancellationToken = default)
        {
            if (condition is null)
            {
                return null;
            }

            return await _dbContext.Employees
                .FirstOrDefaultAsync(
                    employee => condition.Invoke(employee), cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
