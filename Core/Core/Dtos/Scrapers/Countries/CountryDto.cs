using Newtonsoft.Json;

namespace Core.Dtos.Scrapers.Countries
{
    public class CountryDto
    {
        [JsonProperty("flags")]
        public CountryFlagDto Flags { get; set; }

        [JsonProperty("translations")]
        public CountryTranslationDto Translations { get; set; }

        [JsonProperty("ccn3")]
        public string ISOCode { get; set; }
    }
}
