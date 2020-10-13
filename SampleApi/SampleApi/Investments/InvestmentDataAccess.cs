using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Investments
{
    public class InvestmentDataAccess : IInvestmentDataAccess
    {
        public Stock GetCurrentStockPrice(int stockId)
        {
            //assumption: normally this would be connecting to a database
            try
            {
                return DataStore.Stocks.SingleOrDefault(s => s.StockId == stockId);
            }
            //assumption: we would handle the error. possibly logging, returning an error code
            //              capturing it prevents returning the DB error message
            catch (Exception)
            {
                throw new Exception($"Unable to GetCurrentStockPrice {stockId}");
            }
            
        }

        public IEnumerable<InvestmentTransaction> GetTransactionsByUser(int userId)
        {
            //assumption: normally this would be connecting to a database
            try
            {
                return DataStore.InvestmentTransactions.Where(i => i.UserId == userId).ToList();
            }
            //assumption: we would handle the error. possibly logging, returning an error code
            //              capturing it prevents returning the DB error message
            catch (Exception)
            {
                throw new Exception($"Unable to GetTransactionsByUser {userId}");
            }
        }

        public InvestmentTransaction GetTransationById(int transactionId)
        {
            //assumption: normally this would be connecting to a database
            try
            {
                return DataStore.InvestmentTransactions.SingleOrDefault(i => i.TransactionId == transactionId);
            }
            //assumption: we would handle the error. possibly logging, returning an error code
            //              capturing it prevents returning the DB error message
            catch (Exception)
            {
                throw new Exception($"Unable to GetTransationById {transactionId}");
            }
        }
    }
}
