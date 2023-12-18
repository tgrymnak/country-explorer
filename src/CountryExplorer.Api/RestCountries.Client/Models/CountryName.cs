using Newtonsoft.Json;

namespace RestCountries.Client.Models
{
	public record CountryName
	{
		[JsonProperty("common")]
		public string Common { get; set; }

		[JsonProperty("official")]
		public string Official { get; set; }

		[JsonProperty("nativeName")]
		public IDictionary<string, Translation> NativeName { get; set; }
	}
}
