using InvestmentPerformance.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InvestmentPerformance.WebApi.Tests
{
    [TestClass]
    public class InvestmentDetailsTests
    {
        [TestMethod]
        public void Investment_CurrentValue()
        {
            var investmentDetails = new InvestmentDetails()
            {
                Shares = 100,
                CurrentPrice = 352.43M
            };

            Assert.AreEqual(35243.0M, investmentDetails.CurrentValue);
        }

        [TestMethod]
        public void UserInvestment_ShortTerm()
        {
            var investmentDetails = new InvestmentDetails()
            {
                DatePurchased = DateTime.UtcNow.AddMonths(-1)
            };

            Assert.AreEqual(Terms.ShortTerm.ToString(), investmentDetails.Term);
        }

        [TestMethod]
        public void UserInvestment_LongTerm()
        {
            var investmentDetails = new InvestmentDetails()
            {
                DatePurchased = DateTime.UtcNow.AddYears(-1)
            };

            Assert.AreEqual(Terms.LongTerm.ToString(), investmentDetails.Term);
        }

        [TestMethod]
        public void UserInvestment_TotalGain()
        {
            var investmentDetails = new InvestmentDetails()
            {
                CostBasis = 218.26M,
                CurrentPrice = 352.43M,
                Shares = 100,
            };

            Assert.AreEqual(13417.0M, investmentDetails.TotalGain);
        }
    }
}
