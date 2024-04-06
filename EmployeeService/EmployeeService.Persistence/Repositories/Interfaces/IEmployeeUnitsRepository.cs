using EmployeeService.Models.Entities;

namespace EmployeeService.Persistence.Repositories.Interfaces
{
    public interface IEmployeeUnitsRepository
    {
        public Task AddAsync(
            EmployeeUnit employeeUnit,
            CancellationToken cancellationToken = default); 
    }
}
