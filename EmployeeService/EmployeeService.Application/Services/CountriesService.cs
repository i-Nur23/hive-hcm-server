using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using EmployeeService.Persistence.Repositories.Interfaces;

namespace EmployeeService.Application.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesService(
            IDatabaseRepository databaseRepository,
            ICountriesRepository countriesRepository)
        {
            _databaseRepository = databaseRepository;
            _countriesRepository = countriesRepository;
        }

        public async Task AddOrUpdateAsync(List<Country> countries, CancellationToken cancellationToken = default)
        {
            await _databaseRepository.BeginTransactionAsync(cancellationToken);

            try
            {
                List<int> isoCodes = await _countriesRepository.GetAllIsoCodes(cancellationToken);
                List<Country> addingCountries = new List<Country>();
                List<Country> modifyingCountries = new List<Country>();

                foreach (Country country in countries)
                {
                    if (isoCodes.Contains(country.ISOCode))
                    {
                        modifyingCountries.Add(country);
                    }
                    else
                    {
                        addingCountries.Add(country);
                    }
                }

                await _countriesRepository.AddAsync(addingCountries, cancellationToken);
                await _countriesRepository.UpdateAsync(modifyingCountries, cancellationToken);

                await _databaseRepository.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _databaseRepository.RollbackTransactionAsync(cancellationToken);
            }
        }
    }
}
