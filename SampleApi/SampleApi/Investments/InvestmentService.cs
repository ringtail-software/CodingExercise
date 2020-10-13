using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Investments
{
    public class InvestmentService
    {
        private readonly IInvestmentDataAccess _dataAccess;
        public InvestmentService(IInvestmentDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public InvestmentModel GetInvestment(int investmentId)
        {
            //assumption: we'd be getting the transaction from the db
            var transaction = _dataAccess.GetTransationById(investmentId);

            //assumption: this would actually be a different service, getting live stock prices
            var stock = _dataAccess.GetCurrentStockPrice(transaction.StockId);

            return new InvestmentModel
            {
                InvestmentId = transaction.TransactionId,
                InvestmentName = stock.StockName,
                SharesOwned = transaction.ShareQuantity,
                CurrentPricePerShare = stock.CurrentStockPrice,
                CostBasisPerShare = transaction.CostPerShare,
                Term = transaction.TransactionDate < DateTime.Today.AddYears(-1) 
                    ? ShareTerm.LongTerm 
                    : ShareTerm.ShortTerm
            };
        }

        public IEnumerable<InvestmentHeader> GetInvestmentsByUser(int userId)
        {
            return _dataAccess
                .GetTransactionsByUser(userId)
                .OrderBy(t => t.TransactionDate)
                .Select(t => new InvestmentHeader { 
                    InvestmentId = t.TransactionId, 
                    // assumption - Investment name is stock name and date (instead of just stock name)
                    InvestmentName = $"{t.StockName} - {t.TransactionDate:d} "})
                .ToList();
        }
    }
}
