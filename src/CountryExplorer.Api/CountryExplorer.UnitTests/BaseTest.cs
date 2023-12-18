using CountryExplorer.BusinessLogic.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CountryExplorer.UnitTests
{
	public abstract class BaseTest
	{
		private readonly IServiceCollection _serviceCollection;
		private readonly IConfiguration _configuration;

		public BaseTest()
		{
			_serviceCollection = new ServiceCollection().AddLogging(builder => builder.AddConsole());
			_configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json", optional: true).Build();
			_serviceCollection.AddBusinessLogic(_configuration);
		}

		protected void AddService<T>(T implementation) where T : class
		{
			_serviceCollection.AddTransient(e => implementation);
		}

		protected void RemoveService<T>() where T : class
		{
			var descriptor = _serviceCollection.LastOrDefault(e => e.ServiceType == typeof(T));
			if (descriptor != null)
			{
				_serviceCollection.Remove(descriptor);
			}
		}

		protected T GetService<T>() where T : class
		{
			return _serviceCollection.BuildServiceProvider().GetRequiredService<T>();
		}
	}
}
