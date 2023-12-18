using AutoMapper;
using CountryExplorer.Domain.Models;
using CountryExplorer.Domain.Services;
using CountryExplorer.Infrastructure.Logging;
using Microsoft.Extensions.Logging;
using RestCountries.Client;

namespace CountryExplorer.Infrastructure.Services
{
	internal class CountryService : BaseService, ICountryService
	{
		private readonly ILogger<CountryService> _logger;

		public CountryService(IMapper mapper, IRestCountriesClient countriesSource, ILogger<CountryService> logger)
			: base(mapper, countriesSource)
		{
			_logger = logger;
		}

		public async Task<IEnumerable<Country>> GetCountries(CancellationToken ct = default)
		{
			try
			{
				_logger.LogAttempt(LogMessages.GetCountriesMessageFormat);

				var countries = await CountriesSource.GetAll(ct);
				if (countries == null)
				{
					_logger.LogUnable(LogMessages.GetCountriesMessageFormat);
				}
				else
				{
					_logger.LogSucceed(LogMessages.GetCountriesMessageFormat);
				}

				return Mapper.Map<IEnumerable<Country>>(countries);
			}
			catch (Exception ex)
			{
				_logger.LogFailed(ex, LogMessages.GetCountriesMessageFormat);
				throw;
			}
		}

		public async Task<Country> GetCountryByName(string name, CancellationToken ct = default)
		{
			try
			{
				_logger.LogAttempt(LogMessages.GetCountryByNameMessageFormat, name);

				var country = await CountriesSource.GetByName(name, ct);
				if (country == null)
				{
					_logger.LogUnable(LogMessages.GetCountryByNameMessageFormat, name);
				}
				else
				{
					_logger.LogSucceed(LogMessages.GetCountryByNameMessageFormat, name);
				}

				return Mapper.Map<Country>(country);
			}
			catch (Exception ex)
			{
				_logger.LogFailed(ex, LogMessages.GetCountryByNameMessageFormat, name);
				throw;
			}
		}
	}
}
