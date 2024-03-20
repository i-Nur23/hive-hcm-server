using ScrapersService.Countries.Clients.Interfaces;
using ScrapersService.Countries.Dtos;

namespace ScrapersService.Countries.Clients
{
    public class CountriesClient : ICountriesClient
    {
        private readonly HttpClient _httpClient;

        public CountriesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<CountryInfo>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
