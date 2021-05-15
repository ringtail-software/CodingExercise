using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Models;

namespace InvestmentPerformance.Api.RequestHandlers.Users.GetUserInvestment
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
