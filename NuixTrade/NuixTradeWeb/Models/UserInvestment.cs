using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuixTrade.Models
{
	public class UserInvestment : IUserInvestment
	{
		private InvestmentProduct _investmentProduct;
		private TradeTransaction _purchaseTransaction;
		private Logger _nLogger;

		public UserInvestment(Logger nLogger, InvestmentProduct investmentProduct, TradeTransaction purchaseTransaction)
		{
			if (nLogger == null)
				throw new ArgumentNullException("Missing logger");
			if (investmentProduct == null)
				throw new ArgumentNullException("Missing investmentProduct");
			if (purchaseTransaction == null)
				throw new ArgumentNullException("Missing tradeTransaction");

			_nLogger = nLogger;
			_investmentProduct = investmentProduct;
			_purchaseTransaction = purchaseTransaction;
		}

		public decimal GetCostPerBasisShare()
		{
			return _purchaseTransaction.GetTotalPurchasePrice();
		}

		public InvestmentProduct GetInvestmentProduct()
		{
			return _investmentProduct;
		}

		public TradeTransaction GetPurchaseTransaction()
		{
			return _purchaseTransaction;
		}

		public decimal GetTotalGainLoss()
		{
			return _investmentProduct.CurrentPrice * _purchaseTransaction.NumShares - _purchaseTransaction.GetTotalPurchasePrice();
		}

		public InvestmentTerm GetTerm()
		{
			InvestmentTerm term = InvestmentTerm.Short;
			try
			{
				TimeSpan timeSpanDiff = _investmentProduct.CurrentPriceDate.Subtract(_purchaseTransaction.TradeDate);
				int days = timeSpanDiff.Days;
				if (days > 365) // for now, ignoring leap year
					term = InvestmentTerm.Long;
			}
			catch (Exception ex)
			{
				_nLogger.Error(ex, $"Exception getting term");
			}

			return term;
		}

		public decimal GetCurrentValue()
		{
			return _investmentProduct.CurrentPrice * _purchaseTransaction.NumShares;
		}
	}
}