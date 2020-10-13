using NUnit.Framework;
using SampleApi.Investments;

namespace SampleApi_NUnitTestProject
{
    public class Tests
    {
        private InvestmentModel investmentModelWithGains;
        private InvestmentModel investmentModelWithLosses;

        [SetUp]
        public void Setup()
        {
            investmentModelWithGains = new InvestmentModel
            {
                InvestmentId = 1,
                InvestmentName = "Test",
                SharesOwned = 10,
                CurrentPricePerShare = 3,
                CostBasisPerShare = 2,
                Term = ShareTerm.LongTerm.ToString()
                //expected CurrentValue = 30
                //expected TotalGainLoss = +10
            };

            investmentModelWithLosses = new InvestmentModel
            {
                InvestmentId = 1,
                InvestmentName = "Test",
                SharesOwned = 10,
                CurrentPricePerShare = 2,
                CostBasisPerShare = 3,
                Term = ShareTerm.LongTerm.ToString()
                //expected CurrentValue = 20
                //expected TotalGainLoss = -10
            };
        }

        [Test]
        public void ConfirmInvestmentModelCalculationsCorrect()
        {
            Assert.AreEqual(investmentModelWithGains.CurrentValue, 30);
            Assert.AreEqual(investmentModelWithGains.TotalGainLoss, 10);
            Assert.AreEqual(investmentModelWithLosses.CurrentValue, 20);
            Assert.AreEqual(investmentModelWithLosses.TotalGainLoss, -10);
        }

        // assumption: we would normally mock IInvestmentDataAccess and confirm that methods work properly,
        //              but it seems silly since it's already static data, and this is a quick sample
    }
}