using Core.Dtos.Scrapers.Countries;
using Microsoft.Extensions.DependencyInjection;
using ScrapersService.Countries.Clients.Interfaces;

namespace ScrapersService.Countries.Tests
{
    public class ClientTests
    {
        private readonly ICountriesClient _countriesClient;

        public ClientTests()
        {
            var services = new ServiceCollection();
            services.RegisterCountriesScraper();
            var serviceProvider = services.BuildServiceProvider();
            _countriesClient = serviceProvider.GetRequiredService<ICountriesClient>();
        }

        [Test]
        public async Task GetAllCountriesWorksAsync()
        {
            IEnumerable<CountryDto> countries = await _countriesClient.GetAllAsync();

            Assert.IsNotNull(countries);
            Assert.IsNotEmpty(countries);
        }
    }
}
