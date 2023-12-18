using CountryExplorer.BusinessLogic.Handlers.Core;
using CountryExplorer.BusinessLogic.Models.Dtos;
using CountryExplorer.BusinessLogic.Models.Requests;
using CountryExplorer.Domain.Models;

namespace CountryExplorer.BusinessLogic.Handlers
{
	public interface ICountryHandler :
		IHandler<GetCountriesRequest, IEnumerable<CountryPartialDto>>,
		IHandler<GetCountryByNameRequest, Country>
	{ }
}
