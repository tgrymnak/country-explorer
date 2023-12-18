using AutoMapper;
using CountryExplorer.BusinessLogic.Handlers.Core;
using CountryExplorer.BusinessLogic.Models.Dtos;
using CountryExplorer.BusinessLogic.Models.Requests;
using CountryExplorer.Domain.Models;
using CountryExplorer.Domain.Services;
using Microsoft.Extensions.Logging;

namespace CountryExplorer.BusinessLogic.Handlers.Implementation
{
	internal class CountryHandler : BaseHandler, ICountryHandler
	{
		private readonly ICountryService _countryService;
		private readonly IMapper _mapper;
		private readonly ILogger<CountryHandler> _logger;

		public CountryHandler(IServiceProvider serviceProvider,
			ICountryService countryService,
			IMapper mapper,
			ILogger<CountryHandler> logger)
			: base(serviceProvider)
		{
			_countryService = countryService;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<HandlerResponse<IEnumerable<CountryPartialDto>>> Handle(GetCountriesRequest request, HandlerOptions options)
		{
			try
			{
				var result = await _countryService.GetCountries(options.CancellationToken);
				var response = _mapper.Map<IEnumerable<CountryPartialDto>>(result.ToArray());
				return new HandlerResponse<IEnumerable<CountryPartialDto>>(response);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Unable to retrieve countries");
				return HandlerResponse<IEnumerable<CountryPartialDto>>.Error500(ex);
			}
		}

		public async Task<HandlerResponse<Country>> Handle(GetCountryByNameRequest request, HandlerOptions options)
		{
			try
			{
				var validationResult = await Validate(request, options.CancellationToken);
				if (!validationResult.IsValid)
				{
					return new HandlerResponse<Country>(validationResult);
				}

				var response = await _countryService.GetCountryByName(request.Name, options.CancellationToken);
				return new HandlerResponse<Country>(response);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Unable to retrieve country");
				return HandlerResponse<Country>.Error500(ex);
			}
		}
	}
}
