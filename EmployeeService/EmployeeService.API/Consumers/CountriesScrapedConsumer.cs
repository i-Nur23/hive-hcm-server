using Core.Events;
using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using MassTransit;

namespace EmployeeService.API.Consumers
{
    public class CountriesScrapedConsumer : IConsumer<CountriesScrapedEvent>
    {
        private readonly ICountriesService _countriesService;

        public CountriesScrapedConsumer(
            ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        public async Task Consume(ConsumeContext<CountriesScrapedEvent> context)
        {
            List<Country> countries = context.Message.Countries
                .Select(country => new Country()
                {
                    ISOCode = Int32.TryParse(country.ISOCode, out int value) ? value : 0,
                    Name = country.Translations.RussianTranslate.Common,
                    UrlPng = country.Flags.UrlPng,
                    UrlSvg = country.Flags.UrlSvg,
                })
                .ToList();

            await _countriesService.AddOrUpdateAsync(countries);
        }
    }
}
