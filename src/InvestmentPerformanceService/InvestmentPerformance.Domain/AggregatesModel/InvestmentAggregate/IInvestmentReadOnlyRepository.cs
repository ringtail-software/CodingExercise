using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate
{
    public interface IInvestmentReadOnlyRepository
    {
        Task<Investment> GetInvestmentAsync(int userId);

        Task<InvestmentDetail> GetInvestmentDetailsAsync(int investmentId);
    }
}
