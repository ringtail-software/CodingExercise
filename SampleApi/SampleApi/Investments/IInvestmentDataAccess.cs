using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Investments
{
    public interface IInvestmentDataAccess
    {
        IEnumerable<InvestmentTransaction> GetTransactionsByUser(int userId);
        InvestmentTransaction GetTransationById(int transactionId);
        Stock GetCurrentStockPrice(int stockId);

    }
}
