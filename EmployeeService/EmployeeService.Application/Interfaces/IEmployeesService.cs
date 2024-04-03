using Core.Events;
using EmployeeService.Models.Dtos;
using EmployeeService.Models.Entities;

namespace EmployeeService.Application.Interfaces
{
    public interface IEmployeesService
    {
        public Task<Employee> GetEmployeeByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        public Task UpdateAsync(
            UserUpdatedEvent userUpdated,
            CancellationToken cancellationToken = default);

        public Task AddCeoAsync(
            CompanyCreatedEvent newCeo,
            CancellationToken cancellationToken = default);

        public Task AddEmployeeAsync(
            NewUserDto newUserDto,
            CancellationToken cancellationToken = default);

        public Task SetEmployeeAsync(
            SetUserDto setUserDto,
            CancellationToken cancellationToken = default);

        public Task<List<Employee>> GetSubEmployeesAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        public Task<List<Employee>> GetAllAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        public Task RemoveFromUnitAsync(
            RemoveWorkerDto removeWorkerDto,
            CancellationToken cancellationToken = default);
    }
}
