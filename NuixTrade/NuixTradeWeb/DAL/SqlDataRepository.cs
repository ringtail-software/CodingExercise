using NLog;
using NuixTrade.DAL;
using NuixTrade.Models;
using System;
using System.Collections.Generic;

/*
The SQL database contains the following tables/fields:

InvestmentProduct - Holds all possible stocks, etc that a user can buy
		Id - PK int, not null
		Name - varchar(50), not null
		CurrentPrice - money, not null
		CurrentPriceDate - datetime, not null

TradeTransaction - Holds all individual buy/sell trades by users
		TradeId - PK int, not null
		UserId - FK int, not null
		TransactionType char[1], not null - choices are 'B'uy or 'S'ell
		TradeDate - datetime, not null
		NumShares - int, null
		SharePrice - money, null
*/

namespace NuixTradeWeb.DAL
{
	public class SqlDataRepository : IDataRepository
	{
		private Logger _nLogger;

		public SqlDataRepository(Logger nLogger)
		{
			_nLogger = nLogger;
		}

		public IEnumerable<UserInvestment> GetAllUserInvestments(int userId)
		{
			// When implemented, the method runs this query:
			string sql = $@"SELECT TradeId, UserId, TransactionType, TradeDate, NumShares, SharePrice
							FROM TradeTransaction
							WHERE UserId = @userId";

			throw new NotImplementedException();
		}

		public IEnumerable<InvestmentProduct> GetProductLine()
		{
			// When implemented, the method runs this query:
			string sql = $@"SELECT Id, Name, CurrentPrice, CurrentPriceDate 
							FROM InvestmentProduct";

			throw new NotImplementedException();
		}
	}
}