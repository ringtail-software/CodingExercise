using InvestmentPerformance.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPerformance.Services
{
    public interface IInvestmentService
    {
        Task<IEnumerable<Investment>> GetInvestmentList(Guid userGuid);
        Task<InvestmentDetails> GetInvestmentPerformanceDetails(Guid userGuid, string investmentName);

    }
}