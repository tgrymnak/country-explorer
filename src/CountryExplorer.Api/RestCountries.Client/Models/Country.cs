using Newtonsoft.Json;

namespace RestCountries.Client.Models
{
	public class Country
	{
		[JsonProperty("name")]
		public CountryName Name { get; set; }

		[JsonProperty("independent")]
		public bool Independent { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("unMember")]
		public bool UnMember { get; set; }

		[JsonProperty("currencies")]
		public IDictionary<string, Currency> Currencies { get; set; }

		[JsonProperty("capital")]
		public IEnumerable<string> Capital { get; set; }

		[JsonProperty("region")]
		public string Region { get; set; }

		[JsonProperty("subregion")]
		public string Subregion { get; set; }

		[JsonProperty("languages")]
		public IDictionary<string, string> Languages { get; set; }

		[JsonProperty("area")]
		public decimal? Area { get; set; }

		[JsonProperty("flag")]
		public string? FlagCode { get; set; }

		[JsonProperty("maps")]
		public Maps? Maps { get; set; }

		[JsonProperty("population")]
		public int Population { get; set; }

		[JsonProperty("timezones")]
		public IEnumerable<string> Timezones { get; set; }

		[JsonProperty("continents")]
		public IEnumerable<string> Continents { get; set; }

		[JsonProperty("flags")]
		public Flags Flags { get; set; }
	}
}
