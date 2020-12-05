using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuixTrade.Models;

namespace NuixTrade.Tests
{
	[TestClass]
	public class InvestmentProductTests
	{
		[TestMethod]
		public void GetProduct_DateIsInFuture_ThrowException()
		{
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new InvestmentProduct(1, "myName", 123.45M, DateTime.Now.AddDays(1)));
		}

		[TestMethod]
		public void GetProduct_MissingName_ThrowException()
		{
			Assert.ThrowsException<ArgumentException>(() => new InvestmentProduct(1, "", 123.45M, DateTime.Now));
		}
	}
}
