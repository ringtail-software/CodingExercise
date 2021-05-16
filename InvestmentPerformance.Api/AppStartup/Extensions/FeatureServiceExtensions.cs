using Microsoft.Extensions.DependencyInjection;
using InvestmentPerformance.Api.Features.Shared.Services;
using InvestmentPerformance.Api.Features.Shared.Services.Interfaces;

namespace InvestmentPerformance.Api.AppStartup.Extensions
{
    public static class FeatureServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
            services.AddScoped<IInvestmentProvider, InvestmentProvider>();

            return services;
        }
    }
}
