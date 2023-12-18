using Newtonsoft.Json;

namespace RestCountries.Client.Models
{
	public record Translation
	{
		[JsonProperty("official")]
		public string Official { get; set; }

		[JsonProperty("common")]
		public string Common { get; set; }
	}
}
