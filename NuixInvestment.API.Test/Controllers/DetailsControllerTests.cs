using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NuixInvestment.API.Controllers;
using Xunit;
using Xunit.Abstractions;

namespace NuixInvestment.API.Test.Controllers
{
	public class DetailsControllerTests
	{
		private readonly ITestOutputHelper output;
		private readonly IConfiguration configuration;

		public DetailsControllerTests(ITestOutputHelper output)
		{
			ServiceProvider serviceProvider = TestServiceProvider.GetProvider();
			configuration = serviceProvider.GetService<IConfiguration>();
			this.output = output;
		}

		[Theory]
		[InlineData("714")]
		public void Index_StateUnderTest_ExpectedBehavior(string Id)
		{
			// Arrange
			var controller = new DetailsController(configuration);
			controller.ControllerContext.HttpContext = new DefaultHttpContext();
			controller.ControllerContext.HttpContext.Request.Headers["ApiKey"] = configuration["ApiKey"];

			// Act
			var result = controller.Index(Id) as OkObjectResult;

			// Assert
			Assert.Contains("472", result.Value.ToString());
			output.WriteLine(result.Value.ToString());
		}
	}
}