using Newtonsoft.Json;

namespace Core.Dtos.Scrapers.Countries
{
    public class CountryTranslationDto
    {
        [JsonProperty("rus")]
        public CountryNameDto RussianTranslate { get; set; }
    }
}
