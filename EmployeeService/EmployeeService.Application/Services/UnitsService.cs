using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;

namespace EmployeeService.Application.Services
{
    public class UnitsService : IUnitsService
    {
        private readonly IUnitsRepository _unitsRepository;
        private readonly IDatabaseRepository _databaseRepository;

        public UnitsService(
            IDatabaseRepository databaseRepository,
            IUnitsRepository unitsRepository)
        {
            _databaseRepository = databaseRepository;
            _unitsRepository = unitsRepository;
        }

        public async Task<IEnumerable<Unit>> GetLeadingUnitsAsync(
            Guid employeeId, 
            CancellationToken cancellationToken = default)
        {
            return await _unitsRepository.GetUnitsAsync(unit => unit.LeadId.Equals(employeeId));
        }

        public async Task<Unit> GetUnitAsync(
            Guid unitId, 
            CancellationToken cancellationToken = default)
        {
            return await _unitsRepository.GetUnitAsync(unit => unit.Id.Equals(unitId));
        }
    }
}
