using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvestmentPerformance.Api.Features.Shared.Models;
using InvestmentPerformance.Api.Features.Shared.Services.Interfaces;

namespace InvestmentPerformance.Api.Features.Investments.RequestHandlers.GetInvestmentList
{
    public class GetInvestmentListRequestHandler : IRequestHandler<GetInvestmentListRequest, ActionResult<IEnumerable<GetInvestmentsListModel>>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IInvestmentProvider _investmentProvider;

        public GetInvestmentListRequestHandler(ICurrentUserProvider currentUserProvider, IInvestmentProvider investmentProvider)
        {
            _currentUserProvider = currentUserProvider;
            _investmentProvider = investmentProvider;
        }

        public async Task<ActionResult<IEnumerable<GetInvestmentsListModel>>> Handle(GetInvestmentListRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserProvider.GetCurrentUserId();

            return (await _investmentProvider.GetActiveUserInvestments(currentUserId, cancellationToken)).ToList();
        }
    }
}
