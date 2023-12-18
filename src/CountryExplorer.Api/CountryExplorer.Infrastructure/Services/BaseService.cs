using AutoMapper;
using RestCountries.Client;

namespace CountryExplorer.Infrastructure.Services
{
	internal abstract class BaseService
	{
		protected IMapper Mapper { get; }
		protected IRestCountriesClient CountriesSource { get; }
		protected BaseService(IMapper mapper, IRestCountriesClient countriesSource)
		{
			Mapper = mapper;
			CountriesSource = countriesSource;
		}
	}
}
