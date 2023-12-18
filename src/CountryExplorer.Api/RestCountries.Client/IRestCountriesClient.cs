using RestCountries.Client.Models;

namespace RestCountries.Client
{
	public interface IRestCountriesClient
	{
		Task<IEnumerable<Country>?> GetAll(CancellationToken ct = default);
		Task<Country?> GetByName(string name, CancellationToken ct = default);
	}
}
