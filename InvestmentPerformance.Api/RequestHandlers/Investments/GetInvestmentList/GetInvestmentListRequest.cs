using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Models;
using System.Collections.Generic;

namespace InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList
{
    public class GetInvestmentListForUserRequest : IRequest<ActionResult<IEnumerable<GetInvestmentsListModel>>>
    {
    }
}
