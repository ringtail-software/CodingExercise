using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace InvestmentPerformance.Api.Authorization
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == Auth0ClaimTypes.Scope && c.Issuer == requirement.Domain))
                return Task.CompletedTask;

            if (context.User.IsInRole(requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
