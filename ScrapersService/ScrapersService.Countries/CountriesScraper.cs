using Core.Dtos.Scrapers.Countries;
using Core.Events;
using MassTransit;
using Microsoft.Extensions.Hosting;
using ScrapersService.Countries.Clients.Interfaces;
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
            IEnumerable<CountryDto> countries = await _countriesClient.GetAllAsync(stoppingToken);

            await _publishEndpoint.Publish(new CountriesScrapedEvent()
            {
                Countries = countries
            });

            await Task.Delay(TimeSpan.FromDays(7));
        }
    }
}
