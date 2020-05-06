using System;
using System.Threading.Tasks;
using InvestmentPerformance.Domain.AggregatesModel;

namespace InvestmentPerformance.API.Services.Interfaces
{
    public interface IInvestmentService
    {
        Task<Investment> GetInvestmentAsync(int userId);

        Task<InvestmentDetail> GetInvestmentDetailsAsync(int investmentId);
    }
}
