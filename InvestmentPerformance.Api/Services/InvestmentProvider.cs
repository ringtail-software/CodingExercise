using InvestmentPerformance.Api.Entities;
using InvestmentPerformance.Api.Models;
using InvestmentPerformance.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentPerformance.Api.Services
{
    public class InvestmentProvider : IInvestmentProvider
    {
        private readonly InvestmentPerformanceDbContext _dbContext;

        public InvestmentProvider(InvestmentPerformanceDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<GetInvestmentsListModel>> GetActiveUserInvestments(string userId, CancellationToken cancellationToken) =>
            await _dbContext
                .UserInvestments
                .Where(ui => ui.UserId == userId && (ui.Active ?? false))
                .Select(ui => new GetInvestmentsListModel
                {
                    Id = ui.InvestmentId,
                    Name = ui.Investment.Name
                })
                .ToArrayAsync(cancellationToken);

        public async Task<GetInvestmentModel> GetUserInvestment(string userId, int investmentId, CancellationToken cancellationToken)
        {
            var userInvestment = await _dbContext
               .UserInvestments
               .FirstOrDefaultAsync(ui => ui.UserId == userId && ui.InvestmentId == investmentId && (ui.Active ?? false), cancellationToken);

            if (userInvestment == null)
            {
                return null;
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
