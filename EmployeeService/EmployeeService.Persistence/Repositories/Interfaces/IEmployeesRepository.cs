using EmployeeService.Models.Entities;
using System.Linq.Expressions;

namespace EmployeeService.Persistence.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        public Task<Employee?> GetAsync(
            Expression<Func<Employee, bool>> condition,
            bool isCountryIncluded = true,
            bool isUnitsIncluded = true,
            CancellationToken cancellationToken = default);

        public Task<List<Employee?>> GetAllAsync(
            Expression<Func<Employee, bool>> condition = null,
            bool isCountryIncluded = true,
            bool isUnitsIncluded = true,
            CancellationToken cancellationToken = default);

        public Task AddAsync(
            Employee employee,
            CancellationToken cancellationToken = default);

        public Task UpdateAsync(
            Employee employee,
            CancellationToken cancellationToken = default);

        public Task RemoveFromUnitAsync(
            Guid employeeId,
            Guid unitId,
            CancellationToken cancellationToken = default);
    }
}