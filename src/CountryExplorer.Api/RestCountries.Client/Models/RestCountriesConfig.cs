namespace RestCountries.Client.Models
{
	public record RestCountriesConfig
	{
		public string Url { get; set; }
		public string ApiVersion { get; set; }
	}
}
