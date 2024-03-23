using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Persistence.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly IEmployeeServiceDbContext _employeeServiceDbContext;

        public CountriesRepository(
            IEmployeeServiceDbContext employeeServiceDbContext)
        {
            _employeeServiceDbContext = employeeServiceDbContext;
        }

        public async Task AddAsync(
            List<Country> countries, 
            CancellationToken cancellationToken = default)
        {
            await _employeeServiceDbContext.Countries.AddRangeAsync(countries, cancellationToken);

            await _employeeServiceDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Country>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _employeeServiceDbContext.Countries
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<List<int>> GetAllIsoCodes(CancellationToken cancellationToken = default)
        {
            return await _employeeServiceDbContext.Countries
                .Select(c => c.ISOCode)
                .ToListAsync();
        }

        public async Task UpdateAsync(
            List<Country> countries, 
            CancellationToken cancellationToken = default)
        {
            _employeeServiceDbContext.Countries.UpdateRange(countries);

            await _employeeServiceDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
