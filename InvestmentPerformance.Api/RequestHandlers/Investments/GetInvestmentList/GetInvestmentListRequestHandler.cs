using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Models;
using InvestmentPerformance.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList
{
    public class GetInvestmentListForUserRequestHandler : IRequestHandler<GetInvestmentListForUserRequest, ActionResult<IEnumerable<GetInvestmentsListModel>>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IInvestmentProvider _investmentProvider;

        public GetInvestmentListForUserRequestHandler(ICurrentUserProvider currentUserProvider, IInvestmentProvider investmentProvider)
        {
            _currentUserProvider = currentUserProvider;
            _investmentProvider = investmentProvider;
        }

        public async Task<ActionResult<IEnumerable<GetInvestmentsListModel>>> Handle(GetInvestmentListForUserRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserProvider.GetCurrentUserId();

            return (await _investmentProvider.GetActiveUserInvestments(currentUserId, cancellationToken)).ToList();
        }
    }
}
