using Core.Events;

namespace StudyService.Application.Interfaces
{
    public interface IEmployeesService
    {
        public Task AddAsync(
            Guid id,
            string name,
            string surname,
            string email,
            CancellationToken cancellationToken = default);

        public Task UpdateAsync(
            Guid id,
            string name,
            string surname,
            string email,
            CancellationToken cancellationToken = default);

        public Task DeleteAsync(
            EmployeeFireEvent @event,
            CancellationToken cancellationToken = default);
    }
}
