namespace RestCountries.Client.Constants
{
	internal static class ApiUrls
	{
		private const string FilterBase = "?fields=name,currencies,capital,region,languages";
		private const string FilterFull = "?fields=name,currencies,capital,region,subregion,languages,area,maps,population,flags";

		public static Uri GetCountries(string origin, string apiVersion) => new($"{origin}/{apiVersion}/all{FilterBase}");
		public static Uri GetCountryByName(string origin, string apiVersion, string name) => new($"{origin}/{apiVersion}/name/{name}{FilterFull}");
	}
}
