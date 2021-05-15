using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Models;
using System.Collections.Generic;

namespace InvestmentPerformance.Api.RequestHandlers.Users.GetUserInvestmentList
{
    public class GetUserInvestmentListRequest : IRequest<ActionResult<IEnumerable<GetInvestmentsListModel>>>
    {
        public GetUserInvestmentListRequest(string userId) => UserId = userId;

        public string UserId { get; }
    }
}
