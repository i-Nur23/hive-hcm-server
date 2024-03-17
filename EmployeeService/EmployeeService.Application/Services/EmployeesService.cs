using Core.Enums;
using Core.Events;
using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;

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
                    Units = new List<Unit>
                    {
                        new Unit 
                        {
                            Name = "Корневое подразделение",
                            LeadId = newCeo.Id,
                            Company = company,
                        }
                    },
                    Role = Role.CEO
                };

                await _employeesRepository.AddAsync(ceo, cancellationToken);

                await _databaseRepository.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _databaseRepository.RollbackTransactionAsync(cancellationToken);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                await _databaseRepository.BeginTransactionAsync(cancellationToken);

                var employee = await _employeesRepository.GetAsync(
                    employee => employee.Id.Equals(id), 
                    cancellationToken);

                await _databaseRepository.CommitTransactionAsync(cancellationToken);

                return employee;
            }
            catch (Exception ex)
            {
                await _databaseRepository.RollbackTransactionAsync(cancellationToken);
            }

            return null;
        }
    }
}
