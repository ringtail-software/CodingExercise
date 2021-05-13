using Microsoft.Extensions.DependencyInjection;
using InvestmentPerformance.Api.Services;
using InvestmentPerformance.Api.Services.Interfaces;

namespace InvestmentPerformance.Api.Ioc
{
    public static class FeatureServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();

            return services;
        }
    }
}
