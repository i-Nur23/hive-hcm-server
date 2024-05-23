using Core.Dtos.Scrapers.Countries;
using Core.Events;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScrapersService.Countries.Clients.Interfaces;

namespace ScrapersService.Countries
{
    public class CountriesScraper : BackgroundService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IServiceProvider _serviceProvider;

        public CountriesScraper(
            IPublishEndpoint publishEndpoint,
            IServiceProvider serviceProvider)
        {
            _publishEndpoint = publishEndpoint; 
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)   
            {
                IServiceScope serviceScope = _serviceProvider.CreateScope();
                ICountriesClient countriesClient = serviceScope.ServiceProvider.GetRequiredService<ICountriesClient>();

                try
                {
                    IEnumerable<CountryDto> countries = await countriesClient.GetAllAsync(stoppingToken);

                    await _publishEndpoint.Publish(new CountriesScrapedEvent()
                    {
                        Countries = countries
                    });    
                }
                finally
                {
                    serviceScope.Dispose();
                    await Task.Delay(TimeSpan.FromDays(7));   
                }   
            }
        }
    }
}
