using Core.Enums;
using Core.Events;
using Core.Exceptions;
using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace EmployeeService.Application.Services
{
    internal class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IDatabaseRepository _databaseRepository;

        public EmployeesService(
            IEmployeesRepository employeesRepository, 
            IDatabaseRepository databaseRepository)
        {
            _employeesRepository = employeesRepository; 
            _databaseRepository = databaseRepository;
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
            CancellationToken cancellationToken)
        {
            return (await _employeesRepository
                .GetAllAsync(e => e.Units.Any(u => u.LeadId.Equals(id))))
                .Distinct()
                .ToList();
        }
    }
}
