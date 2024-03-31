using Core.Exceptions;
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

        public async Task AddUnitAsync(
            Guid? parentUnitId, 
            Guid leadId, 
            string name, 
            CancellationToken cancellationToken = default)
        {
            Guid companyId = Guid.Empty;

            if (parentUnitId is not null)
            {
                Unit parentUnit = await _unitsRepository.GetUnitAsync(
                    u => u.Id.Equals(parentUnitId),
                    cancellationToken);

                if (parentUnit is null)
                {
                    throw new NotFoundException("Родительское подразделение не найдено");
                }

                Unit existingUnit = await _unitsRepository.GetUnitAsync(
                    u => u.Name.Equals(name) && u.ParentUnitId.Equals(parentUnitId),
                    cancellationToken);

                if (existingUnit is not null)
                {
                    throw new BadRequestException("Подразделение уже существует");
                }

                companyId = parentUnit.CompanyId;
            }
            else
            {

            }

            Unit unit = new Unit()
            {
                Id = Guid.NewGuid(),
                Name = name,
                ParentUnitId = parentUnitId,
                LeadId = leadId,
                CompanyId = companyId
            };

            await _unitsRepository.AddUnitAsync(unit, cancellationToken);

        }
    }
}
