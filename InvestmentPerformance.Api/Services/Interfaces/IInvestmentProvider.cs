using InvestmentPerformance.Api.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentPerformance.Api.Services.Interfaces
{
    public interface IInvestmentProvider
    {
        Task<IEnumerable<GetInvestmentsListModel>> GetActiveUserInvestments(string userId, CancellationToken cancellationToken);
        Task<GetInvestmentModel> GetUserInvestment(string userId, int investmentId, CancellationToken cancellationToken);
    }
}
