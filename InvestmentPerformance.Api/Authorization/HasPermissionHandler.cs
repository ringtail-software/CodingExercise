using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace InvestmentPerformance.Api.Authorization
{
    public class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == CustomClaimTypes.Permissions && c.Issuer == requirement.Domain))
                return Task.CompletedTask;

            if (context.User.IsInRole(requirement.Permission))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
