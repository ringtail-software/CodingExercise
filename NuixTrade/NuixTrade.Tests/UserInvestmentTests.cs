using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuixTrade.Models;
using NLog;

namespace NuixTrade.Tests
{
	[TestClass]
	public class UserInvestmentTests
	{
		private static Logger _nLogger = LogManager.GetCurrentClassLogger();

		[TestMethod]
		public void GetCostBasisPerShare_TypicalValues_ExpectCorrectAnswer()
		{
			// Arrange
			decimal originalSharePrice = 125.44M;
			int numShares = 44;
			InvestmentProduct investmentProduct = new InvestmentProduct(1, "ABC", 1223.67M, DateTime.Now);
			TradeTransaction purchaseTransaction = new TradeTransaction(_nLogger, 1, TransactionType.Buy,DateTime.Now, numShares, originalSharePrice);
			UserInvestment userInvestment = new UserInvestment(_nLogger, investmentProduct, purchaseTransaction);

			// Act
			decimal basisCost = userInvestment.GetCostPerBasisShare();

			// Assert
			Assert.AreEqual(originalSharePrice * numShares, basisCost);
		}

		[TestMethod]
		public void GetTotalGainLoss_PriceDropped_ExpectCorrectNegativeAnswer()
		{
			// Arrange
			decimal originalSharePrice = 125.44M;
			decimal currentPrice = 99.33M;
			int numShares = 44;
			InvestmentProduct investmentProduct = new InvestmentProduct(1, "ABC", currentPrice, DateTime.Now);
			TradeTransaction purchaseTransaction = new TradeTransaction(_nLogger, 1, TransactionType.Buy, DateTime.Now.AddMonths(-4), numShares, originalSharePrice);
			UserInvestment userInvestment = new UserInvestment(_nLogger, investmentProduct, purchaseTransaction);

			// Act
			decimal loss = userInvestment.GetTotalGainLoss();

			// Assert
			decimal expectedLoss = (currentPrice - originalSharePrice) * numShares;
			Assert.AreEqual(expectedLoss, loss);
		}

		[TestMethod]
		public void GetTerm_LessThan366_expectShort()
		{
			// Arrange
			decimal originalSharePrice = 125.44M;
			decimal currentPrice = 99.33M;
			int numShares = 44;
			DateTime currentDate = new DateTime(2020, 5, 12);
			DateTime purchaseDate = new DateTime(2020, 1, 15);
			InvestmentProduct investmentProduct = new InvestmentProduct(1, "ABC", currentPrice, currentDate);
			TradeTransaction purchaseTransaction = new TradeTransaction(_nLogger, 1, TransactionType.Buy, purchaseDate, numShares, originalSharePrice);
			UserInvestment userInvestment = new UserInvestment(_nLogger, investmentProduct, purchaseTransaction);

			// Act
			InvestmentTerm actualTerm = userInvestment.GetTerm();

			// Assert
			Assert.AreEqual(InvestmentTerm.Short, actualTerm);
		}

		[TestMethod]
		public void GetTerm_GreaterThan365_expectLong()
		{
			// Arrange
			decimal originalSharePrice = 125.44M;
			decimal currentPrice = 99.33M;
			int numShares = 44;
			DateTime currentDate = new DateTime(2020, 5, 12);
			DateTime purchaseDate = new DateTime(2018, 1, 15);
			InvestmentProduct investmentProduct = new InvestmentProduct(1, "ABC", currentPrice, currentDate);
			TradeTransaction purchaseTransaction = new TradeTransaction(_nLogger, 1, TransactionType.Buy, purchaseDate, numShares, originalSharePrice);
			UserInvestment userInvestment = new UserInvestment(_nLogger, investmentProduct, purchaseTransaction);

			// Act
			InvestmentTerm actualTerm = userInvestment.GetTerm();

			// Assert
			Assert.AreEqual(InvestmentTerm.Long, actualTerm);
		}
	}
}
