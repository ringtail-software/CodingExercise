using Microsoft.Extensions.DependencyInjection;
using TestServiceProvider;

namespace NuixInvestment.API.Test.Controllers
{
	public static class TestServiceProvider
	{
		internal static ServiceProvider GetProvider()
		{
			var baseServices = new TestServices().BaseServices();
			var serviceProvider = baseServices.BuildServiceProvider();
			return serviceProvider;
		}
	}
}