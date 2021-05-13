using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList.Models;
using System.Collections.Generic;

namespace InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList
{
    public class GetInvestmentsRequest : IRequest<ActionResult<IEnumerable<GetInvestmentsModel>>>
    {
    }
}
