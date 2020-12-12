using InvestmentPerformance.Data.Entities;
using System.Collections.Generic;

namespace InvestmentPerformance.WebAPI.Repository
{
    public interface IInvestmentPerformanceRepository
    {
        public List<UserInvestment> GetAllInvestmentsForUser(int userId);
        public UserInvestment GetInvestmentDetailsById(int userId, int investmentId);
    }
}
