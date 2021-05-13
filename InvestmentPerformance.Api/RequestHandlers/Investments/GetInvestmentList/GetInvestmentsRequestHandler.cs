using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvestmentPerformance.Api.Entities;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList.Models;
using InvestmentPerformance.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList
{
    public class GetInvestmentsRequestHandler : IRequestHandler<GetInvestmentsRequest, ActionResult<IEnumerable<GetInvestmentsModel>>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly InvestmentPerformanceDbContext _dbContext;

        public GetInvestmentsRequestHandler(ICurrentUserProvider currentUserProvider, InvestmentPerformanceDbContext dbContext)
        {
            _currentUserProvider = currentUserProvider;
            _dbContext = dbContext;
        }

        public async Task<ActionResult<IEnumerable<GetInvestmentsModel>>> Handle(GetInvestmentsRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserProvider.GetCurrentUserId();

            return await _dbContext
                .UserInvestments
                .Where(ui => ui.UserId == currentUserId && (ui.Active ?? false))
                .Select(ui => new GetInvestmentsModel
                {
                    Id = ui.InvestmentId,
                    Name = ui.Investment.Name
                })
                .ToArrayAsync(cancellationToken);
        }
    }
}
