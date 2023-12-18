using CountryExplorer.Domain.Services;
using Moq;
using RestCountries.Client;
using Rest = RestCountries.Client.Models;

namespace CountryExplorer.UnitTests
{
	[TestFixture]
	public class CountryServiceTests : BaseTest
	{
		[Test]
		public async Task GetCountries_WhenMocked_ReturnsCountries()
		{
			var countries = new[]
			{
				new Rest.Country
				{
					Name = new Rest.CountryName { Common = "Common", Official = "Official"}
				},
				new Rest.Country
				{
					Name = new Rest.CountryName { Common = "Common 1", Official = "Official 1"}
				}
			};

			var mockRestCountriesClient = new Mock<IRestCountriesClient>();
			mockRestCountriesClient.Setup(e => e.GetAll(It.IsAny<CancellationToken>()))
				.Returns(Task.FromResult<IEnumerable<Rest.Country>?>(countries));

			// inject mock
			AddService<IRestCountriesClient>(mockRestCountriesClient.Object);

			var result = await GetService<ICountryService>().GetCountries();

			foreach (var country in countries)
			{
				var item = result.FirstOrDefault(e => e.Name == country.Name.Common);
				Assert.That(item, Is.Not.Null);
			}

			// remove mock
			RemoveService<IRestCountriesClient>();
		}

		[Test]
		public void GetCountries_WhenConfiguraionMissing_ThrowsException()
		{
			var service = GetService<ICountryService>();
			var ex = Assert.ThrowsAsync<UriFormatException>(() => service.GetCountries());
			Assert.That(ex.Message, Is.EqualTo("Invalid URI: The hostname could not be parsed."));
		}
	}
}
