using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NuixInvestment.API.Controllers;
using Xunit;
using Xunit.Abstractions;

namespace NuixInvestment.API.Test.Controllers
{
	public class InvestmentsControllerTests
	{
		private readonly ITestOutputHelper output;
		private readonly IConfiguration configuration;

		public InvestmentsControllerTests(ITestOutputHelper ouput)
		{
			ServiceProvider serviceProvider = TestServiceProvider.GetProvider();
			configuration = serviceProvider.GetService<IConfiguration>();
			this.output = ouput;
		}

		[Theory]
		[InlineData("714")]
		public void Index_StateUnderTest_ExpectedBehavior(string Id)
		{
			// Arrange
			var controller = new InvestmentsController(configuration);
			controller.ControllerContext.HttpContext = new DefaultHttpContext();
			controller.ControllerContext.HttpContext.Request.Headers["ApiKey"] = configuration["ApiKey"];

			// Act
			var result = controller.Index(Id) as OkObjectResult;

			// Assert
			Assert.Contains("AAPL", result.Value.ToString());
			output.WriteLine(result.Value.ToString());
		}
	}
}