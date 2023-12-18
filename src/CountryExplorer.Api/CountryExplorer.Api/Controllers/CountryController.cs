using CountryExplorer.BusinessLogic.Handlers;
using CountryExplorer.BusinessLogic.Handlers.Core;
using CountryExplorer.BusinessLogic.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CountryExplorer.Api.Controllers
{
	public class CountryController : BaseApiController
	{
		private readonly ICountryHandler _countryHandler;

		public CountryController(ICountryHandler countryHandler)
		{
			_countryHandler = countryHandler;
		}

		[HttpGet("list")]
		[ResponseCache(VaryByHeader = "User-Agent", Duration = 5 * 60)]
		public async Task<IActionResult> GetCountries(CancellationToken ct = default)
		{
			var (code, result) = await _countryHandler.Handle(new GetCountriesRequest(), new HandlerOptions(LoggedInUser, IpAddress, ct));
			return ToActionResult(code, result);
		}

		[HttpGet("{name}")]
		[ResponseCache(VaryByHeader = "User-Agent", Duration = 5 * 60)]
		public async Task<IActionResult> GetCountry([FromRoute] string name, CancellationToken ct = default)
		{
			var (code, result) = await _countryHandler.Handle(new GetCountryByNameRequest(name), new HandlerOptions(LoggedInUser, IpAddress, ct));
			return ToActionResult(code, result);
		}
	}
}
