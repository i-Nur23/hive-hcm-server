using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;

namespace EmployeeService.Persistence.Repositories
{
    public class EmployeeUnitsRepository : IEmployeeUnitsRepository
    {
        private readonly IEmployeeServiceDbContext _dbContext;

        public EmployeeUnitsRepository(
            IEmployeeServiceDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task AddAsync(
            EmployeeUnit employeeUnit,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.EmployeeUnits.AddAsync(employeeUnit, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
