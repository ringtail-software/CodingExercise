using MediatR;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Models;
using InvestmentPerformance.Api.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformance.Api.RequestHandlers.Users.GetUserInvestment
{
    public class GetUserInvestmentRequestHandler : IRequestHandler<GetUserInvestmentRequest, ActionResult<GetInvestmentModel>>
    {
        private readonly IInvestmentProvider _investmentProvider;
        private readonly ILogger<GetUserInvestmentRequestHandler> _logger;

        public GetUserInvestmentRequestHandler(ILogger<GetUserInvestmentRequestHandler> logger, IInvestmentProvider investmentProvider)
        {
            _logger = logger;
            _investmentProvider = investmentProvider;
        }

        public async Task<ActionResult<GetInvestmentModel>> Handle(GetUserInvestmentRequest request, CancellationToken cancellationToken)
        {
            var userInvestmentModel = await _investmentProvider.GetUserInvestment(request.UserId, request.InvestmentId, cancellationToken);

            if (userInvestmentModel == null)
            {
                _logger.LogWarning($"UserInvestment for User {request.UserId} and Investment {request.InvestmentId} not found");
                return new NotFoundResult();
            }

            return userInvestmentModel;
        }
    }
}
