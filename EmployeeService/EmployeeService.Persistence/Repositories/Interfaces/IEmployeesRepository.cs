using EmployeeService.Models.Entities;
using System.Linq.Expressions;

namespace EmployeeService.Persistence.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        public Task<Employee?> GetAsync(
            Expression<Func<Employee, bool>> condition,
            CancellationToken cancellationToken = default);

        public Task AddAsync(
            Employee employee,
            CancellationToken cancellationToken = default);

        public Task UpdateAsync(
            Employee employee,
            CancellationToken cancellationToken = default);
    }
}
