using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment.Models;

namespace InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment
{
    public class GetInvestmentRequest : IRequest<ActionResult<GetInvestmentModel>>
    {
        public GetInvestmentRequest(int investmentId) => InvestmentId = investmentId;

        public int InvestmentId { get; }
    }
}
