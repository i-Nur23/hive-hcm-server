using EmployeeService.Models.Entities;
using System.Linq.Expressions;

namespace EmployeeService.Persistence.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        public Task<Employee?> GetAsync(
            Predicate<Employee> condition,
            CancellationToken cancellationToken = default);
    }
}
