using ScrapersService.Countries.Dtos;

namespace ScrapersService.Countries.Clients.Interfaces
{
    public interface ICountriesClient
    {
        public Task<IEnumerable<CountryInfo>> GetAllAsync(
            CancellationToken cancellationToken = default);
    }
}
