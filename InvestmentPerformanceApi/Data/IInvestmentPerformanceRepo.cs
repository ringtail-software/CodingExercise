using InvestmentPerformanceApi.Models;
using System.Collections.Generic;

namespace InvestmentPerformanceApi.Data
{
    public interface IInvestmentPerformanceRepo
    {
        IEnumerable<Investments> Get(int userId);
        IEnumerable<InvestmentDetails> GetDetails(int userId, int investmentId);
        void Buy(InvestmentDetails buy);
        //bool SaveChanges();
        void Update(IEnumerable<InvestmentDetails> investModel);
        void Sell(IEnumerable<InvestmentDetails> sell);
    }
}
