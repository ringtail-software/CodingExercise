using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Models;
using InvestmentPerformance.Api.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment
{
    public class GetInvestmentRequestHandler : IRequestHandler<GetInvestmentRequest, ActionResult<GetInvestmentModel>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IInvestmentProvider _investmentProvider;
        private readonly ILogger<GetInvestmentRequestHandler> _logger;

        public GetInvestmentRequestHandler(ICurrentUserProvider currentUserProvider, ILogger<GetInvestmentRequestHandler> logger, IInvestmentProvider investmentProvider)
        {
            _currentUserProvider = currentUserProvider;
            _logger = logger;
            _investmentProvider = investmentProvider;
        }

        public async Task<ActionResult<GetInvestmentModel>> Handle(GetInvestmentRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserProvider.GetCurrentUserId();

            var userInvestmentModel = await _investmentProvider.GetUserInvestment(currentUserId, request.InvestmentId, cancellationToken);

            if (userInvestmentModel == null)
            {
                _logger.LogWarning($"UserInvestment for User {currentUserId} and Investment {request.InvestmentId} not found");
                return new NotFoundResult();
            }

            return userInvestmentModel;
        }
    }
}
