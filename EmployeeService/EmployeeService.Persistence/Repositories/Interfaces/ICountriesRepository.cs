using EmployeeService.Models.Entities;

namespace EmployeeService.Persistence.Repositories.Interfaces
{
    public interface ICountriesRepository
    {
        public Task<List<int>> GetAllIsoCodes(
            CancellationToken cancellationToken = default);

        public Task AddAsync(
            List<Country> countries,
            CancellationToken cancellationToken = default);

        public Task UpdateAsync(
            List<Country> countries, 
            CancellationToken cancellationToken = default);
    }
}
