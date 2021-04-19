using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestServiceProvider
{
	public class TestServices
	{
		/// <summary>
		/// Base services including IConfiguration, Configuration from appsettings.json, and IHttpClientFactory
		/// </summary>
		/// <returns></returns>
		public ServiceCollection BaseServices()
		{
			var services = new ServiceCollection();
			services.AddHttpClient();
			services.AddTransient<IConfiguration>(sp =>
			{
				IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
				configurationBuilder.AddJsonFile("appsettings.json");
				return configurationBuilder.Build();
			});

			return services;
		}
	}
}