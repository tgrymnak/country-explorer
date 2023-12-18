using Microsoft.Extensions.DependencyInjection;
using CountryExplorer.Infrastructure.Extensions;
using CountryExplorer.BusinessLogic.Handlers;
using CountryExplorer.BusinessLogic.Handlers.Implementation;
using FluentValidation;
using CountryExplorer.BusinessLogic.Validators;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace CountryExplorer.BusinessLogic.Extensions
{
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// Adds application business logic
		/// </summary>
		/// <param name="services">Collection of application services</param>
		/// <param name="configuration">Application configuration properties</param>
		public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddInfrastructure(configuration);

			services.AddTransient<ICountryHandler, CountryHandler>();

			// Register validators
			services.AddValidatorsFromAssemblyContaining<GetCountryByNameRequestValidator>(ServiceLifetime.Transient);

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
		}
	}
}
