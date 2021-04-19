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
	public class InvestmentsControllerTests
	{
		private readonly ITestOutputHelper output;
		private readonly IConfiguration configuration;
		private readonly IHttpClientFactory clientFactory;
		private readonly InvestmentsController controller;

		public InvestmentsControllerTests(ITestOutputHelper ouput)
		{
			// Arrange
			ServiceProvider serviceProvider = TestServiceProvider.GetProvider();
			configuration = serviceProvider.GetService<IConfiguration>();
			clientFactory = serviceProvider.GetService<IHttpClientFactory>();
			this.output = ouput;
			controller = new InvestmentsController(configuration, clientFactory);
		}

		[Theory]
		[InlineData("714")]
		public async Task IndexTest(string Id)
		{
			// Act
			var response = await controller.Index(Id) as OkObjectResult;
			var result = JsonConvert.SerializeObject(response.Value);

			// Assert
			Assert.Contains("AAPL", result);
			output.WriteLine(result);
		}
	}
}