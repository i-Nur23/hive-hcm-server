using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeService.Persistence.Repositories
{
    public class UnitsRepository : IUnitsRepository 
    {
        private IEmployeeServiceDbContext _employeeServiceDbContext;

        public UnitsRepository(
            IEmployeeServiceDbContext employeeServiceDbContext)
        {
            _employeeServiceDbContext = employeeServiceDbContext;
        }

        public async Task<Unit> GetUnitAsync(
            Expression<Func<Unit, bool>> condition, 
            CancellationToken cancellationToken = default)
        {
            return await _employeeServiceDbContext.Units
                .AsNoTracking()
                .FirstOrDefaultAsync(condition, cancellationToken);
        }

        public async Task<IEnumerable<Unit>> GetUnitsAsync(
            Expression<Func<Unit, bool>> 
            condition, CancellationToken cancellationToken = default)
        {
            return await _employeeServiceDbContext.Units
                .AsNoTracking()
                .Where(condition)
                .Include(u => u.Workers)
                .Include(u => u.ChildUnits)
                .ToListAsync(cancellationToken);
        }

        public async Task AddUnitAsync(
            Unit unit, 
            CancellationToken cancellationToken = default)
        {
            await _employeeServiceDbContext.Units.AddAsync(unit, cancellationToken);

            await _employeeServiceDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
