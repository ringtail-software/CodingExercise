using NUnit.Framework;
using BusinessObjects;
using System;

namespace InvestmentPerformanceTest
{
    [TestFixture]
    public class InvestmentTests
    {
        [Test]
        public void GetTerm_PurchasedAfter10292019_returnShortTerm()
        {
            System.DateTime purchaseDate = Convert.ToDateTime("10/30/2019");
            API oAPI = new API();
            string term= oAPI.GetTerm(purchaseDate);
            Assert.AreEqual("Short Term", term);
        }
        [Test]
        public void GetTerm_PurchasedOneYearBefore_returnLongTerm()
        {
            System.DateTime purchaseDate = Convert.ToDateTime("10/28/2019");
            API oAPI = new API();
            string term = oAPI.GetTerm(purchaseDate);
            Assert.AreEqual("Long Term", term);
        }
        [Test]
        public void GetTerm_PurchasedOneYear_returnShortTerm()
        {
            System.DateTime purchaseDate = Convert.ToDateTime("10/29/2019");
            API oAPI = new API();
            string term = oAPI.GetTerm(purchaseDate);
            Assert.AreEqual("Short Term", term);
        }

        public void GetTerm_PurchasedOneYearAfter_returnShortTerm()
        {
            System.DateTime purchaseDate = Convert.ToDateTime("12/20/2019");
            API oAPI = new API();
            string term = oAPI.GetTerm(purchaseDate);
            Assert.AreEqual("Short Term", term);
        }
        [Test]
        public void GetTerm_FuturePurchasedDate_returnError()
        {
            System.DateTime purchaseDate = Convert.ToDateTime("12/20/2021");
            API oAPI = new API();
            string term = oAPI.GetTerm(purchaseDate);
            Assert.AreEqual("Invalid purchase date.", term);
        }
        [Test]
        public void CalculateCurrentValue_ReturnCurrentPriceMultiplyNumberofShares()
        {
            int numberOfShares = 50;
            double currentPrice = 25.53;
            double currentValue = numberOfShares * currentPrice;
            API oAPI = new API();
            double ret = oAPI.CalculateCurrentValue(numberOfShares, currentPrice);
            Assert.AreEqual(currentValue, ret);
        }
        [Test]
        public void CalculateTotalLostGains_CurrentValueGreaterThanTotalPurchedValue_returnGain()
        {
            int numberOfShares = 50;
            double currentPrice = 25.53;
            double basicCostPerShare = 20.53;
            double currentValue = numberOfShares * currentPrice;
            double totalCost= numberOfShares * basicCostPerShare;
            double totalGainLost = currentValue - totalCost;
            API oAPI = new API();
            double ret = oAPI.CalculateTotalLostGains(numberOfShares, currentPrice, basicCostPerShare);
            Assert.AreEqual(totalGainLost, ret);
        }

        [Test]
        public void CalculateTotalLostGains_CurrentValueLessThanTotalPurchedValue_returnLost()
        {
            int numberOfShares = 50;
            double currentPrice = 25.53;
            double basicCostPerShare = 32.53;
            double currentValue = numberOfShares * currentPrice;
            double totalCost = numberOfShares * basicCostPerShare;
            double totalGainLost = currentValue - totalCost;
            API oAPI = new API();
            double ret = oAPI.CalculateTotalLostGains(numberOfShares, currentPrice, basicCostPerShare);
            Assert.AreEqual(totalGainLost, ret);
        }
  

        [Test]
        public void GetInvestments_InvalidInvestorID_returnError()
        {
            try
            {
                Investor investor = new Investor { InvestorID = 10, InvestorName = "Jone" };
                InvestmentDatabase oDB = new InvestmentDatabase(investor);
                API oAPI = new API(oDB);
                oAPI.GetInvestments(15);
                Assert.Fail();
            }
            catch { Assert.Pass(); }
        }

        [Test]
        public void GetInvestmentDetails_InvalidInvestorID_returnError()
        {
            try
            {
                Investor investor = new Investor { InvestorID = 10, InvestorName = "Jone" };
                InvestmentDatabase oDB = new InvestmentDatabase(investor);
                API oAPI = new API(oDB);
                oAPI.GetInvestmentDetails(11, 1);
                Assert.Fail();
            }
            catch { Assert.Pass(); }
        }

        [Test]
        public void GetInvestmentDetails_InvalidInvestmentID_returnError()
        {
            try
            {
                Investor investor = new Investor { InvestorID = 10, InvestorName = "Jone" };
                InvestmentDatabase oDB = new InvestmentDatabase(investor);
                API oAPI = new API(oDB);
                oAPI.GetInvestmentDetails(10,1);
                Assert.Fail();
            }
            catch { Assert.Pass(); }
        }
    }
}