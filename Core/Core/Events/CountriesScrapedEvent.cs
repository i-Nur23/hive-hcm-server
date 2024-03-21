using Core.Dtos.Scrapers.Countries;

namespace Core.Events
{
    public class CountriesScrapedEvent
    {
        public IEnumerable<CountryDto> Countries { get; set; }
    }
}
