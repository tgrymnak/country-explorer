using Newtonsoft.Json;

namespace RestCountries.Client.Models
{
	public record Maps
	{
		[JsonProperty("googleMaps")]
		public string GoogleMaps { get; set; }

		[JsonProperty("openStreetMaps")]
		public string OpenStreetMaps { get; set; }
	}
}
