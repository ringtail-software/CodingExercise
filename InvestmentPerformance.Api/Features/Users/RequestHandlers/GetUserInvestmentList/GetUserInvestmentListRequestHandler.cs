using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvestmentPerformance.Api.Features.Shared.Models;
using InvestmentPerformance.Api.Features.Shared.Services.Interfaces;

namespace InvestmentPerformance.Api.Features.Users.RequestHandlers.GetUserInvestmentList
{
    public class GetUserInvestmentListRequestHandler : IRequestHandler<GetUserInvestmentListRequest, ActionResult<IEnumerable<GetInvestmentsListModel>>>
    {
        private readonly IInvestmentProvider _investmentProvider;

        public GetUserInvestmentListRequestHandler(IInvestmentProvider investmentProvider) => _investmentProvider = investmentProvider;

        public async Task<ActionResult<IEnumerable<GetInvestmentsListModel>>> Handle(GetUserInvestmentListRequest request, CancellationToken cancellationToken) =>
            (await _investmentProvider.GetActiveUserInvestments(request.UserId, cancellationToken)).ToList();
    }
}
