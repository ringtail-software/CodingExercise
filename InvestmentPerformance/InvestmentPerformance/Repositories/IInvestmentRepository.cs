using InvestmentPerformance.Dtos;
using System;
using System.Collections.Generic;

namespace InvestmentPerformance.Repositories
{
    public interface IInvestmentRepository
    {
        IEnumerable<InvestmentDto> GetInvestments(Guid userGuid);
        InvestmentTransactionDto GetInvestmentDetails(Guid userGuid, string investmentName);

    }



}