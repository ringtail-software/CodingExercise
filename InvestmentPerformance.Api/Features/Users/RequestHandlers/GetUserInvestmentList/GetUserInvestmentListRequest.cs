using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InvestmentPerformance.Api.Features.Shared.Models;

namespace InvestmentPerformance.Api.Features.Users.RequestHandlers.GetUserInvestmentList
{
    public class GetUserInvestmentListRequest : IRequest<ActionResult<IEnumerable<GetInvestmentsListModel>>>
    {
        public GetUserInvestmentListRequest(string userId) => UserId = userId;

        public string UserId { get; }
    }
}
