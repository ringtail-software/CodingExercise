using InvestmentPerformance.Api.Authorization;
using InvestmentPerformance.Api.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace InvestmentPerformance.Api.AppStartup.Extensions
{
    public static class AuthorizationExtensions
    {
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
                        RoleClaimType = CustomClaimTypes.Permissions, // allow us to call User.IsInRole on "permissions" claim
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationPolicies.IsAdmin, policy => policy.Requirements.Add(new HasPermissionRequirement(UserRoles.Admin, domain)));
            });

            services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();

            return services;
        }
    }
}
