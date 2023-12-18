using CountryExplorer.Domain.Models;

namespace CountryExplorer.Domain.Services
{
	public interface ICountryService
	{
		Task<IEnumerable<Country>> GetCountries(CancellationToken ct = default);
		Task<Country> GetCountryByName(string name, CancellationToken ct = default);
	}
}