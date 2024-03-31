using Core.Enums;
using Core.Events;
using Core.Exceptions;
using Core.Responses;
using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Dtos;
using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;
using MassTransit;

namespace EmployeeService.Application.Services
{
    internal class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IRequestClient<NewUserEvent> _newUserRequestClient;
        private readonly IUnitsRepository _unitsRepository;

        public EmployeesService(
            IEmployeesRepository employeesRepository, 
            IDatabaseRepository databaseRepository,
            IRequestClient<NewUserEvent> newUserRequestClient,
            IUnitsRepository unitsRepository)
        {
            _employeesRepository = employeesRepository; 
            _databaseRepository = databaseRepository;
            _newUserRequestClient = newUserRequestClient;
            _unitsRepository = unitsRepository;
        }

        public async Task AddCeoAsync(
            CompanyCreatedEvent newCeo, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _databaseRepository.BeginTransactionAsync(cancellationToken);
                
                Company company = new Company() 
                { 
                    Name = newCeo.CompanyName,
                };

                Employee ceo = new Employee()
                {
                    Email = newCeo.Email,
                    Id = newCeo.Id,
                    Name = newCeo.Name,
                    Surname = newCeo.Surname,
                    RoleType = Role.CEO
                };

                await _employeesRepository.AddAsync(ceo, cancellationToken);

                await _databaseRepository.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _databaseRepository.RollbackTransactionAsync(cancellationToken);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(
            Guid id, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _databaseRepository.BeginTransactionAsync(cancellationToken);

                var employee = await _employeesRepository.GetAsync(
                    employee => employee.Id.Equals(id), 
                    cancellationToken: cancellationToken);

                await _databaseRepository.CommitTransactionAsync(cancellationToken);

                return employee;
            }
            catch (Exception ex)
            {
                await _databaseRepository.RollbackTransactionAsync(cancellationToken);
            }

            return null;
        }

        public async Task UpdateAsync(
            UserUpdatedEvent userUpdated, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _databaseRepository.BeginTransactionAsync(cancellationToken);

                Employee employee = await _employeesRepository.GetAsync(e => e.Id.Equals(userUpdated.UserId));

                if (employee is null)
                {
                    throw new NotFoundException("Пользователь не найден");
                }

                employee.BirthDate = userUpdated.BirthDate;
                employee.Email = userUpdated.Email;
                employee.Name = userUpdated.Name;
                employee.Patronimic = userUpdated.Patronymic;
                employee.PhoneNumber = userUpdated.PhoneNumber;
                employee.City = userUpdated.City;
                employee.CountryCode = userUpdated.CountryCode;
                employee.Surname = userUpdated.Surname;

                await _employeesRepository.UpdateAsync(employee, cancellationToken);

                await _databaseRepository.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _databaseRepository.RollbackTransactionAsync(cancellationToken);

                throw;
            }
        }

        public async Task<List<Employee>> GetSubEmployeesAsync(
            Guid id, 
            CancellationToken cancellationToken = default)
        {
            return (await _employeesRepository
                .GetAllAsync(e => e.Units.Any(u => u.LeadId.Equals(id))))
                .Distinct()
                .ToList();
        }

        public async Task AddEmployeeAsync(
            NewUserDto newUserDto, 
            CancellationToken cancellationToken = default)
        {
            await _databaseRepository.BeginTransactionAsync(cancellationToken);

            try
            {
                Guid id = Guid.NewGuid();

                Employee employee = new Employee()
                {
                    Id = id,
                    Email = newUserDto.Email,
                    Name = newUserDto.Name,
                    Surname = newUserDto.Surname,
                    RoleType = newUserDto.Role,
                    EmployeeUnits = new List<EmployeeUnit>(){ new EmployeeUnit()
                    {
                        EmployeeId = id,
                        UnitId = newUserDto.UnitId,
                    }}
                };

                await _employeesRepository.AddAsync(employee, cancellationToken);

                var response = await _newUserRequestClient.GetResponse<BaseResponse>(new NewUserEvent()
                {
                    Email = newUserDto.Email,
                    Id = id,
                    Name = newUserDto.Name,
                    Role = newUserDto.Role,
                    Surname = newUserDto.Surname
                },
                cancellationToken,
                RequestTimeout.After(s: 30));

                if (!response.Message.IsSuccess)
                {
                    throw new BadRequestException("Ошибка при выполнении запроса");
                }

                await _databaseRepository.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _databaseRepository.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        public async Task SetEmployeeAsync(
            SetUserDto setUserDto, 
            CancellationToken cancellationToken = default)
        {
            Employee employee = await _employeesRepository.GetAsync(e => e.Id.Equals(setUserDto.UserId));

            if (employee is null)
            {
                throw new BadRequestException("Пользователь не найден");
            }

            Unit unit = await _unitsRepository.GetUnitAsync(u => u.Id.Equals(setUserDto.UnitId));

            if (unit is null)
            {
                throw new BadRequestException("Подразделение не найдено");
            }

            employee.Units.Add(unit);

            await _employeesRepository.UpdateAsync(employee, cancellationToken);
        }
    }
}
