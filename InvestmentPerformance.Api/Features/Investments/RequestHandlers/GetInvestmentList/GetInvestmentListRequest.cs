using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InvestmentPerformance.Api.Features.Shared.Models;

namespace InvestmentPerformance.Api.Features.Investments.RequestHandlers.GetInvestmentList
{
    public class GetInvestmentListRequest : IRequest<ActionResult<IEnumerable<GetInvestmentsListModel>>>
    {
    }
}
