using Newtonsoft.Json;

namespace RestCountries.Client.Models
{
	public record Currency
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("symbol")]
		public string Symbol { get; set; }
	}
}
