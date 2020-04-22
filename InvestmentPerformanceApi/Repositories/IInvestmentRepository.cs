using InvestmentPerformanceApi.Models;
using System.Collections.Generic;

namespace InvestmentPerformanceApi.Repositories
{
    public interface IInvestmentRepository
    {
        IEnumerable<Investment> GetInvestmentsByUser(int userId);

        InvestmentPerformance GetInvestmentDetail(int investmentId);
    }
}
