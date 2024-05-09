using Core.Events;
using StudyService.Application.Interfaces;
using StudyService.Models.Entities;
using StudyService.Persistence;
using StudyService.Persistence.Repositories.Interfaces;

namespace StudyService.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly DatabaseManager _databaseManager;
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesService(
            IEmployeesRepository employeesRepository,
            DatabaseManager databaseManager)
        {
            _employeesRepository = employeesRepository;
            _databaseManager = databaseManager;
        }

        public async Task AddAsync(
            Guid id, 
            string name, 
            string surname, 
            string email, 
            CancellationToken cancellationToken = default)
        {
            Employee employee = new Employee
            {
                Id = id,
                Email = email,
                Name = name,
                Surname = surname,
            };

            await _employeesRepository.AddAsync(employee, cancellationToken);
        }

        public async Task UpdateAsync(
            Guid id, 
            string name, 
            string surname, 
            string email, 
            CancellationToken cancellationToken = default)
        {
            Employee employee = new Employee
            {
                Id = id,
                Name = name,
                Surname = surname,
                Email = email
            };

            await _employeesRepository.UpdateAsync(employee, cancellationToken);
        }

        public async Task DeleteAsync(
            EmployeeFireEvent @event,
            CancellationToken cancellationToken = default)
        {
            await _employeesRepository.DeleteAsync(@event.EmployeeId, cancellationToken);
        }
    }
}
