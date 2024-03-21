using Core.Dtos.Scrapers.Countries;
using Newtonsoft.Json;
using ScrapersService.Countries.Clients.Interfaces;
using System.Text.Json.Serialization;

namespace ScrapersService.Countries.Clients
{
    public class CountriesClient : ICountriesClient
    {
        private readonly HttpClient _httpClient;

        private string _baseUrl = "https://restcountries.com/v3.1/all";

        public CountriesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(
                $"{_baseUrl}?fields=translations,flags,ccn3",
                cancellationToken);

            var textBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<CountryDto>>(textBody);

            return result;
        }
    }
}
