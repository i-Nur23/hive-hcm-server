using Newtonsoft.Json;

namespace Core.Dtos.Scrapers.Countries
{
    public class CountryNameDto
    {
        [JsonProperty("common")]
        public string Common { get; set; }

        [JsonProperty("official")]
        public string Official { get; set; }
    }
}
