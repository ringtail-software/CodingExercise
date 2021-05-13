using Microsoft.AspNetCore.Http;
using InvestmentPerformance.Api.Services.Interfaces;
using System;
using System.Security.Claims;

namespace InvestmentPerformance.Api.Services
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            var name = identity.FindFirst(ClaimTypes.NameIdentifier);

            if (name == null)
                throw new ApplicationException("User not found");

            return name.Value;
        }
    }
}
