using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Models;
using InvestmentPerformance.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentPerformance.Api.RequestHandlers.Users.GetUserInvestmentList
{
    public class GetUserInvestmentListRequestHandler : IRequestHandler<GetUserInvestmentListRequest, ActionResult<IEnumerable<GetInvestmentsListModel>>>
    {
        private readonly IInvestmentProvider _investmentProvider;

        public GetUserInvestmentListRequestHandler(IInvestmentProvider investmentProvider) => _investmentProvider = investmentProvider;

        public async Task<ActionResult<IEnumerable<GetInvestmentsListModel>>> Handle(GetUserInvestmentListRequest request, CancellationToken cancellationToken) =>
            (await _investmentProvider.GetActiveUserInvestments(request.UserId, cancellationToken)).ToList();
    }
}
