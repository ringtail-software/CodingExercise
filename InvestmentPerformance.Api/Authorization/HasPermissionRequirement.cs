using Microsoft.AspNetCore.Authorization;
using System;

namespace InvestmentPerformance.Api.Authorization
{
    public class HasPermissionRequirement : IAuthorizationRequirement
    {
        public string Domain { get; }
        public string Permission { get; }

        public HasPermissionRequirement(string permission, string domain)
        {
            if (permission == null)
                throw new ArgumentException("The permission must be provided");

            if (domain == null)
                throw new ArgumentException("The domain must be provided");

            Permission = permission;
            Domain = domain;
        }
    }
}
