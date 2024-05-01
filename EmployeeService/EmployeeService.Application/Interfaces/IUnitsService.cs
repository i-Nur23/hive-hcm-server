using EmployeeService.Models.Dtos;
using EmployeeService.Models.Entities;

namespace EmployeeService.Application.Interfaces
{
    public interface IUnitsService
    {
        public Task<IEnumerable<UnitInfoDto>> GetLeadingUnitsAsync(
            Guid employeeId,
            CancellationToken cancellationToken = default);

        public Task<IEnumerable<UnitInfoDto>> GetCompanyUnitsAsync(
            Guid companyId,
            CancellationToken cancellationToken = default);

        public Task<Unit> GetUnitAsync(
            Guid unitId,
            CancellationToken cancellationToken = default);

        public Task AddUnitAsync(
            Guid userId,
            Guid? parentUnit,
            Guid leadId,
            string name,
            CancellationToken cancellationToken = default);

        public Task DeleteUnitAsync(
            Guid unitId,
            CancellationToken cancellationToken = default);
    }
}
