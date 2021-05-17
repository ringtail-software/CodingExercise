using InvestmentPerformance.Api.Features.Shared.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentPerformance.Api.Features.Shared.Services.Interfaces
{
    public interface IInvestmentProvider
    {
        Task<IEnumerable<GetInvestmentsListModel>> GetActiveUserInvestments(string userId, CancellationToken cancellationToken);
        Task<GetInvestmentModel> GetUserInvestment(string userId, int investmentId, CancellationToken cancellationToken);
    }
}
