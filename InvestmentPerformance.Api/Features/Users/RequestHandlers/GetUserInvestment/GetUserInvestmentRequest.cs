using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Features.Shared.Models;

namespace InvestmentPerformance.Api.Features.Users.RequestHandlers.GetUserInvestment
{
    public class GetUserInvestmentRequest : IRequest<ActionResult<GetInvestmentModel>>
    {
        public GetUserInvestmentRequest(string userId, int investmentId)
        {
            UserId = userId;
            InvestmentId = investmentId;
        }

        public string UserId { get; }
        public int InvestmentId { get; }
    }
}
