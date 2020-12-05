using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using NuixTrade.Models;

namespace NuixTrade.DAL
{
	public class DummyDataRepository : IDataRepository
	{
		private Logger _nLogger;

		public DummyDataRepository(Logger nLogger)
		{
			_nLogger = nLogger;
		}

		public IEnumerable<InvestmentProduct> GetProductLine()
		{
			// Not needed for this module, 
			// but will be needed when user is ready to buy more investments

			throw new NotImplementedException();
		}

		public IEnumerable<UserInvestment> GetAllUserInvestments(int userId)
		{
			List<UserInvestment> products = new List<UserInvestment>();
			InvestmentProduct productAbc = new InvestmentProduct(1, "Grogu Heavy Lifting", 1.23M, DateTime.Now);
			TradeTransaction transactionAbc = new TradeTransaction(_nLogger, 1, TransactionType.Buy, new DateTime(2018, 4, 15), 100, 0.55M);
			UserInvestment investmentAbc = new UserInvestment(_nLogger, productAbc, transactionAbc);
			products.Add(investmentAbc);

			InvestmentProduct productBcd = new InvestmentProduct(2, "Guild Enterprises", 44.78M, DateTime.Now);
			TradeTransaction transactionBcd = new TradeTransaction(_nLogger, 1, TransactionType.Buy, new DateTime(2020, 11, 15), 1500, 71.00M);
			UserInvestment investmentBcd = new UserInvestment(_nLogger, productBcd, transactionBcd);
			products.Add(investmentBcd);

			InvestmentProduct productCde = new InvestmentProduct(3, "Karga Holdings", 1434.78M, DateTime.Now);
			TradeTransaction transactionCde = new TradeTransaction(_nLogger, 1, TransactionType.Buy, new DateTime(2019, 2, 1), 50, 1042.55M);
			UserInvestment investmentCde = new UserInvestment(_nLogger, productCde, transactionCde);
			products.Add(investmentCde);

			return products;
		}
	}
}