using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvestmentPerformance.Api.Entities;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment.Models;
using InvestmentPerformance.Api.Services.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment
{
    public class GetInvestmentRequestHandler : IRequestHandler<GetInvestmentRequest, ActionResult<GetInvestmentModel>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly InvestmentPerformanceDbContext _dbContext;
        private readonly ILogger<GetInvestmentRequestHandler> _logger;

        public GetInvestmentRequestHandler(ICurrentUserProvider currentUserProvider, InvestmentPerformanceDbContext dbContext, ILogger<GetInvestmentRequestHandler> logger)
        {
            _currentUserProvider = currentUserProvider;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<ActionResult<GetInvestmentModel>> Handle(GetInvestmentRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserProvider.GetCurrentUserId();

            var userInvestment = await _dbContext
                .UserInvestments
                .FirstOrDefaultAsync(ui => ui.UserId == currentUserId && ui.InvestmentId == request.InvestmentId && ui.Active, cancellationToken);

            if (userInvestment == null)
            {
                _logger.LogWarning($"UserInvestment for User {currentUserId} and Investment {request.InvestmentId} not found");
                return new NotFoundResult();
            }

            await _dbContext.Entry(userInvestment).Reference(ui => ui.Investment).LoadAsync(cancellationToken);
            await _dbContext.Entry(userInvestment).Collection(ui => ui.Purchases).LoadAsync(cancellationToken);

            return new GetInvestmentModel
            {
                Id = userInvestment.InvestmentId,
                Name = userInvestment.Investment.Name,
                NumberOfShares = userInvestment.TotalShares,
                CurrentPrice = userInvestment.Investment.CurrentPrice,
                CurrentValue = userInvestment.CurrentValue,
                Term = userInvestment.Term,
                TotalGain = userInvestment.TotalGain,
                Purchases = userInvestment.Purchases.Select(p => new GetInvestmentPurchaseModel
                {
                    CostBasisPerShare = p.CostBasisPerShare,
                    NumberOfShares = p.NumberOfShares,
                    PurchaseDate = p.CreatedDate
                }),
            };
        }
    }
}
