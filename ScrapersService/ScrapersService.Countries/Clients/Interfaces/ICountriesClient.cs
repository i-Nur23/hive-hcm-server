using Core.Dtos.Scrapers.Countries;

namespace ScrapersService.Countries.Clients.Interfaces
{
    public interface ICountriesClient
    {
        public Task<IEnumerable<CountryDto>> GetAllAsync(
            CancellationToken cancellationToken = default);
    }
}
