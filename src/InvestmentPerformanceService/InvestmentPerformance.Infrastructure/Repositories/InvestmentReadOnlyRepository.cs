using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentPerformance.Domain.AggregatesModel;
using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.Infrastructure.Repositories
{
    /// <summary>
    /// Read only repository to access investment data from database
    /// </summary>
    public class InvestmentReadOnlyRepository : IInvestmentReadOnlyRepository, IDisposable
    {
        private readonly InvestmentPerformanceContext _context;

        public InvestmentReadOnlyRepository(InvestmentPerformanceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Retrieves all investments from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Investment>> GetAllInvestmentsAsync()
        {
            return await _context.Investments.ToArrayAsync();
        }

        /// <summary>
        /// Retrieves all investments for user via the users id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Investment>> GetUserInvestmentsAsync(int userId)
        {
            return await _context.Investments.Where(e => e.UserId == userId).ToArrayAsync();
        }

        /// <summary>
        /// Retrieves investment details for a specific investment via primary key
        /// </summary>
        /// <param name="investmentId"></param>
        /// <returns></returns>
        public async Task<Investment> GetInvestmentAsync(int investmentId)
        {
            return await _context.Investments.FindAsync(investmentId);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
