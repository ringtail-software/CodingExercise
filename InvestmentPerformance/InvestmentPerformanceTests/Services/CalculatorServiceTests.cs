using InvestmentPerformance.Models;
using InvestmentPerformance.Resource;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPerformance.Services.Tests
{
    class CalculatorTests
    {

        [TestCase(10.0,10,0)]
        public void Calculator_CalculateProfit_Test(double purchasedPrice, int shares, double currentPrice)
        {
            double profit = Calculator.CalculateProfit(purchasedPrice, shares, currentPrice);
            Assert.Less(profit, 0);
        }

        [TestCase(10, 0)]
        public void Calculator_CalculateCurrentValue_Test(int shares, double currentPrice)
        {
            double value = Calculator.CalculateCurrentValue(shares, currentPrice);
            Assert.AreEqual(value, 0);
        }

        [TestCase("01/01/1800")]
        public void Calculator_CalculateCurrentValue_Test(DateTime purchaseTimeStamp)
        {
            TermType term = Calculator.CalculateTerm(purchaseTimeStamp);
            Assert.AreEqual(term, TermType.LongTerm);
        }

    }
}


