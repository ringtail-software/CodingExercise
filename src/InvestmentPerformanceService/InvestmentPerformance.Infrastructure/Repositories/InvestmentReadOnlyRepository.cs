using System;
using System.Linq;
using System.Threading.Tasks;
using InvestmentPerformance.Domain.AggregatesModel;
using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.Infrastructure.Repositories
{
    public class InvestmentReadOnlyRepository : IInvestmentReadOnlyRepository
    {
        private readonly InvestmentPerformanceContext _context;

        public InvestmentReadOnlyRepository(InvestmentPerformanceContext context)
        {
            _context = context;
        }

        public async Task<Investment> GetInvestmentAsync(int userId)
        {
            return await _context.Investments.Where(e => e.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<InvestmentDetail> GetInvestmentDetailsAsync(int investmentId)
        {
            return await _context.InvestmentDetails.Where(e => e.InvestmentId == investmentId).FirstOrDefaultAsync();
        }
    }
}
