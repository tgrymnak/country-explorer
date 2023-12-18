namespace CountryExplorer.Domain.Models
{
	public class Country
	{
		public string Name { get; set; }
		public IEnumerable<string> Capital { get; set; }
		public IEnumerable<Currency> Currencies { get; set; }
		public IEnumerable<Language> Languages { get; set; }
		public string Region { get; set; }
		public string Subregion { get; set; }
		public int Population { get; set; }
		public decimal Area { get; set; }
		public string Flag { get; set; }
		public string Map { get; set; }
	}
}
