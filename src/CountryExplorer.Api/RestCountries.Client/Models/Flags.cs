using Newtonsoft.Json;

namespace RestCountries.Client.Models
{
	public record Flags
	{
		[JsonProperty("png")]
		public string Png { get; set; }

		[JsonProperty("svg")]
		public string Svg { get; set; }
	}
}
