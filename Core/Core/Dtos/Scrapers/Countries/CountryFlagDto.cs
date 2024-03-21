using Newtonsoft.Json;

namespace Core.Dtos.Scrapers.Countries
{
    public class CountryFlagDto
    {
        [JsonProperty("png")]
        public string UrlPng { get; set; }

        [JsonProperty("svg")]
        public string UrlSvg { get; set; }

        [JsonProperty("alt")]
        public string Description { get; set; }
    }
}
