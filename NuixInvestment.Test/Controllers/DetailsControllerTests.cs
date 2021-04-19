using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NuixInvestment.Controllers;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace NuixInvestment.Test.Controllers
{
	public class DetailsControllerTests
	{
		private readonly ITestOutputHelper output;
		private readonly IConfiguration configuration;
		private readonly IHttpClientFactory clientFactory;
		private readonly DetailsController controller;

		public DetailsControllerTests(ITestOutputHelper output)
		{
			// Arrange
			ServiceProvider serviceProvider = TestServiceProvider.GetProvider();
			configuration = serviceProvider.GetService<IConfiguration>();
			clientFactory = serviceProvider.GetService<IHttpClientFactory>();
			this.output = output;
			controller = new DetailsController(configuration, clientFactory);
		}

		[Theory]
		[InlineData("714")]
		public async Task IndexTestAsync(string Id)
		{
			// Act
			var response = await controller.Index(Id) as OkObjectResult;
			var result = JsonConvert.SerializeObject(response.Value);

			// Assert
			Assert.Contains("472", result);
			output.WriteLine(result);
		}
	}
}