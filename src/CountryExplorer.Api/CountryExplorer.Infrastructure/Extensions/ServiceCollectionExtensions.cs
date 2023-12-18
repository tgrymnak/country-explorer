using CountryExplorer.Domain.Services;
using CountryExplorer.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestCountries.Client.Extensions;
using System.Reflection;

namespace CountryExplorer.Infrastructure.Extensions
{
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// Adds application infrastructure
		/// </summary>
		/// <param name="services">Collection of application services</param>
		/// <param name="configuration">Application configuration properties</param>
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<ICountryService, CountryService>();

			services.AddRestCountiesClient(configuration);

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
		}
	}
}
