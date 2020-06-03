using InvestmentPerformance.Models;
using System;
using System.Collections.Generic;

namespace InvestmentPerformance.Services
{
    public interface IInvestmentService
    {
        IEnumerable<Investment> GetInvestmentList(Guid userGuid);
        InvestmentDetails GetInvestmentPerformanceDetails(Guid userGuid, string investmentName);

    }
}