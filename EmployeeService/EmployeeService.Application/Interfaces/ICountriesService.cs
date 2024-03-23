using EmployeeService.Models.Entities;

namespace EmployeeService.Application.Interfaces
{
    public interface ICountriesService
    {
        public Task AddOrUpdateAsync(
            List<Country> countries,
            CancellationToken cancellationToken = default);

        public Task<List<Country>> GetAllAsync(
            CancellationToken cancellationToken = default);
    }
}
