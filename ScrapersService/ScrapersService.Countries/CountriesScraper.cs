using MassTransit;
using Microsoft.Extensions.Hosting;
using ScrapersService.Countries.Clients.Interfaces;
using ScrapersService.Countries.Dtos;
using System.ComponentModel;

namespace ScrapersService.Countries
{
    public class CountriesScraper : BackgroundService
    {
        private readonly ICountriesClient _countriesClient;
        private readonly IPublishEndpoint _publishEndpoint;

        public CountriesScraper(
            ICountriesClient countriesClient,
            IPublishEndpoint publishEndpoint)
        {
            _countriesClient = countriesClient;
            _publishEndpoint = publishEndpoint; 
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IEnumerable<CountryInfo> countries = await _countriesClient.GetAllAsync(stoppingToken);

            await Task.Delay(TimeSpan.FromDays(7));
        }
    }
}
