using InvestmentPerformance.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPerformance.WebApi.Repositories
{
    public interface IInvestmentsRepository
    {
        /// <summary>
        /// Get investments for specified user.
        /// </summary>
        Task<IEnumerable<Investment>> GetInvestmentsAsync(int userId);
    }
}
