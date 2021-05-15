using Microsoft.AspNetCore.Authorization;
using System;

namespace InvestmentPerformance.Api.Authorization
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Domain { get; }
        public string Scope { get; }

        public HasScopeRequirement(string scope, string domain)
        {
            if (scope == null)
                throw new ArgumentException("The scope must be provided");

            if (domain == null)
                throw new ArgumentException("The domain must be provided");

            Scope = scope;
            Domain = domain;
        }
    }
}
