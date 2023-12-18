using Microsoft.Extensions.DependencyInjection;
using Polly.Extensions.Http;
using Polly;
using RestCountries.Client.Implementation;
using Microsoft.Extensions.Configuration;
using RestCountries.Client.Models;

namespace RestCountries.Client.Extensions
{
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// Adds REST Countries services
		/// </summary>
		/// <param name="services">Collection of application services</param>
		/// <param name="configuration">Application configuration</param>
		/// <param name="sectionName">Application configuration section name for <see cref="RestCountriesConfig"/></param>
		public static void AddRestCountiesClient(this IServiceCollection services, IConfiguration configuration, string configurationSectionName = nameof(RestCountriesConfig))
		{
			services.Configure<RestCountriesConfig>(configuration.GetSection(configurationSectionName));
			services.AddHttpClient<IRestCountriesClient, RestCountriesClient>()
				.SetHandlerLifetime(TimeSpan.FromMinutes(5))
				.AddPolicyHandler(GetRetryPolicy());
		}

		private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
		{
			return HttpPolicyExtensions
				.HandleTransientHttpError()
				.WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
		}
	}
}
