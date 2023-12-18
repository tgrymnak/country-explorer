using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestCountries.Client.Constants;
using RestCountries.Client.Models;

namespace RestCountries.Client.Implementation
{
	internal class RestCountriesClient : IRestCountriesClient
	{
		private readonly HttpClient _httpClient;
		private readonly RestCountriesConfig _config;

		public RestCountriesClient(HttpClient httpClient, IOptions<RestCountriesConfig> options)
		{
			_httpClient = httpClient;
			_config = options.Value;
		}

		public async Task<IEnumerable<Country>?> GetAll(CancellationToken ct = default)
		{
			var uri = ApiUrls.GetCountries(_config.Url, _config.ApiVersion);
			var result = await SendAsync<IEnumerable<Country>>(uri, ct);
			return result;
		}

		public async Task<Country?> GetByName(string name, CancellationToken ct = default)
		{
			var uri = ApiUrls.GetCountryByName(_config.Url, _config.ApiVersion, name);
			var result = await SendAsync<IEnumerable<Country>>(uri, ct);
			return result?.FirstOrDefault();
		}

		private async Task<TResponse?> SendAsync<TResponse>(Uri uri, CancellationToken ct = default)
		{
			_httpClient.BaseAddress = new Uri(uri.GetLeftPart(UriPartial.Authority));
			var message = new HttpRequestMessage(HttpMethod.Get, uri.PathAndQuery);
			var result = await _httpClient.SendAsync(message, ct);
			var resultString = await result.Content.ReadAsStringAsync(ct);
			return JsonConvert.DeserializeObject<TResponse>(resultString);
		}
	}
}
