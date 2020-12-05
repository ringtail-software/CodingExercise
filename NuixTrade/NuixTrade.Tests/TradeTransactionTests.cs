using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuixTrade.Models;

namespace NuixTrade.Tests
{
	[TestClass]
	public class TradeTransactionTests
	{
		[TestMethod]
		public void GetTotalPurchasePrice_Use3DecimalPlaceSharePrice_ExpectAccurateResult()
		{
			// Arrange
			decimal purchaseSharePrice = 21.792M;
			int numShares = 432;
			TradeTransaction transaction = new TradeTransaction(null, 1, TransactionType.Buy, DateTime.Now.AddMonths(-4), numShares, purchaseSharePrice);

			// Act
			decimal totalPrice = transaction.GetTotalPurchasePrice();

			// Assert
			Assert.AreEqual(totalPrice, purchaseSharePrice * numShares);
		}
	}
}
