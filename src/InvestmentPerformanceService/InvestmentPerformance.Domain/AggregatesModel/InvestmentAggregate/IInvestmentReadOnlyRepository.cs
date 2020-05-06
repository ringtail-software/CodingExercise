using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPerformance.Domain.SeedWork;

namespace InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate
{
    /// <summary>
    /// Interface/contract for InvestmentReadOnlyRepository
    /// </summary>
    public interface IInvestmentReadOnlyRepository : IRepository<Investment>
    {
        Task<IEnumerable<Investment>> GetAllInvestmentsAsync();

        Task<IEnumerable<Investment>> GetUserInvestmentsAsync(int userId);

        Task<Investment> GetInvestmentAsync(int investmentId);
    }
}
