using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPerformance.API.Application.Models;
using InvestmentPerformance.Domain.AggregatesModel;

namespace InvestmentPerformance.API.Application.Services.Interfaces
{
    public interface IInvestmentService
    {
        Task<IEnumerable<Investment>> GetAllInvestmentsAsync();

        Task<IEnumerable<UserInvestment>> GetUserInvestmentsAsync(int userId);

        Task<InvestmentDetails> GetInvestmentDetailsAsync(int investmentId);
    }
}
