using Microsoft.Extensions.DependencyInjection;
using InvestmentPerformance.Api.Services;
using InvestmentPerformance.Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using InvestmentPerformance.Api.Constants;
using Microsoft.AspNetCore.Authorization;
using InvestmentPerformance.Api.Authorization;

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

        public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var domain = $"https://{configuration["Auth0:Domain"]}/";

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = configuration["Auth0:Audience"];

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier,
                        RoleClaimType = Auth0ClaimTypes.Scope, // allow us to call User.IsInRole on "scope" claim
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationPolicies.IsAdmin, policy => policy.Requirements.Add(new HasScopeRequirement(UserRoles.Admin, domain)));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            return services;
        }
    }
}
