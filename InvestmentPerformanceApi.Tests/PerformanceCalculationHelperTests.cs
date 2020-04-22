using NUnit.Framework;
using System;

namespace InvestmentPerformanceApi.Tests
{
    public class PerformanceCalculationHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1/1/2019", "12/31/2019")] // Full non-leap year
        [TestCase("1/1/2016", "12/30/2016")] // Full leap year minus one day
        [TestCase("6/1/2018", "5/31/2019")] // Cross a year boundry
        public void Less_Than_366_Days_Will_Return_Short(DateTime purchaseDate, DateTime endDate)
        {
            Assert.IsTrue(PerformanceCalculationHelper.GetTerm(purchaseDate, endDate) == Models.Term.Short);
        }

        [TestCase("1/1/2019", "1/1/2020")] // Full non-leap year
        [TestCase("1/1/2016", "12/31/2016")] // All of the dates in a leap year
        [TestCase("6/1/2018", "6/1/2019")] // Cross a year boundry
        public void More_Than_365_Days_Will_Return_Long(DateTime purchaseDate, DateTime endDate)
        {
            Assert.IsTrue(PerformanceCalculationHelper.GetTerm(purchaseDate, endDate) == Models.Term.Long);
        }

        [TestCase(1, 0.01, 0.02)]
        public void NetGain_Should_Be_Negative_If_The_Customer_Lost_Money(int shares, decimal currentPrice, decimal purchaseCostPerShare)
        {
            Assert.IsTrue(PerformanceCalculationHelper.CalculateNetGain(shares, currentPrice, purchaseCostPerShare) < 0);
        }

        [TestCase(1, 0.02, 0.01)]
        public void NetGain_Should_Be_Positive_If_The_Customer_Earned_Money(int shares, decimal currentPrice, decimal purchaseCostPerShare)
        {
            Assert.IsTrue(PerformanceCalculationHelper.CalculateNetGain(shares, currentPrice, purchaseCostPerShare) > 0);
        }
    }
}