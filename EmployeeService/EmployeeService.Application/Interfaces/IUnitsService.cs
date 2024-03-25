using EmployeeService.Models.Entities;

namespace EmployeeService.Application.Interfaces
{
    public interface IUnitsService
    {
        public Task<IEnumerable<Unit>> GetLeadingUnitsAsync(
            Guid employeeId,
            CancellationToken cancellationToken = default);

        public Task<Unit> GetUnitAsync(
            Guid unitId,
            CancellationToken cancellationToken = default);


    }
}
