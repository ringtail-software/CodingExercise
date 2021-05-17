using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Features.Shared.Models;

namespace InvestmentPerformance.Api.Features.Investments.RequestHandlers.GetInvestment
{
    public class GetInvestmentRequest : IRequest<ActionResult<GetInvestmentModel>>
    {
        public GetInvestmentRequest(int investmentId) => InvestmentId = investmentId;

        public int InvestmentId { get; }
    }
}
