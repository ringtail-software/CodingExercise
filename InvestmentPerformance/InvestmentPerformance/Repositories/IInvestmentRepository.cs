using InvestmentPerformance.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPerformance.Repositories
{
    public interface IInvestmentRepository
    {
        Task<List<InvestmentDto>> GetInvestments(Guid userGuid);
        Task<InvestmentTransactionDto> GetInvestmentDetails(Guid userGuid, string investmentName);
    }
}