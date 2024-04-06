using Core.Exceptions;
using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Dtos;
using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;

namespace EmployeeService.Application.Services
{
    public class UnitsService : IUnitsService
    {
        private readonly IUnitsRepository _unitsRepository;
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IEmployeesRepository _employeesRepository;  

        public UnitsService(
            IDatabaseRepository databaseRepository,
            IUnitsRepository unitsRepository,
            IEmployeesRepository employeesRepository)
        {
            _databaseRepository = databaseRepository;
            _unitsRepository = unitsRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<IEnumerable<UnitInfoDto>> GetLeadingUnitsAsync(
            Guid employeeId, 
            CancellationToken cancellationToken = default)
        {
            IEnumerable<Unit> units = 
                await _unitsRepository.GetUnitsAsync(unit => unit.LeadId.Equals(employeeId));

            return units.Select(u => new UnitInfoDto()
            {
                Name = u.Name,
                Id = u.Id,
                Lead = new WorkerBaseDto()
                {
                    Id = u.Lead.Id,
                    Name = u.Lead.Name,
                    Surname = u.Lead.Surname,
                    Patronymic = u.Lead.Patronimic,
                    Email = u.Lead.Email
                },
                Workers = u.Workers.Select(w => new WorkerBaseDto()
                {
                    Id = w.Id,
                    Name = w.Name,
                    Surname = w.Surname,
                    Patronymic = w.Patronimic,
                    Email = w.Email
                }).ToList(),
                ChildUnits = u.ChildUnits.Select(cu => new UnitInfoDto() 
                { 
                    Id = cu.Id,
                    Name = cu.Name,
                    Lead = new WorkerBaseDto()
                    {
                        Id = cu.Lead.Id,
                        Name = cu.Lead.Name,
                        Surname = cu.Lead.Surname,
                        Patronymic = cu.Lead.Patronimic,
                        Email = cu.Lead.Email
                    },
                }).ToList(),
            });
        }

        public async Task<Unit> GetUnitAsync(
            Guid unitId, 
            CancellationToken cancellationToken = default)
        {
            return await _unitsRepository.GetUnitAsync(unit => unit.Id.Equals(unitId));
        }

        public async Task AddUnitAsync(
            Guid userId,
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
                Employee ceo = await _employeesRepository.GetAsync(
                    e => e.Id.Equals(userId),
                    false,
                    false,
                    cancellationToken);

                if (ceo is null)
                {
                    throw new BadRequestException("Пользователь не найден");
                }

                companyId = ceo.CompanyId;
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

        public async Task DeleteUnitAsync(
            Guid unitId, 
            CancellationToken cancellationToken = default)
        {
            await _unitsRepository.DeleteAsync(unitId, cancellationToken);
        }
    }
}
