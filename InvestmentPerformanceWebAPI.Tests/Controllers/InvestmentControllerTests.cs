using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentPerformanceWebAPI;
using InvestmentPerformanceWebAPI.Data;
using InvestmentPerformanceWebAPI.Models;
using InvestmentPerformanceWebAPI.Controllers;
using InvestmentPerformanceWebAPI.Helpers;

namespace InvestmentPerformanceWebAPI.Tests.Controllers
{
    [TestClass]
    public class InvestmentControllerTests
    {
        private IInvestmentContext db = null;

        [TestMethod]
        public void GetInvestments()
        {
            CreateFakeInvestmentContext();

            InvestmentController controller = new InvestmentController(db);

            // get all of the investments
            List<Investment> investments = controller.Get();

            // Asserts
            Assert.IsNotNull(investments);
        }

        [TestMethod]
        public void GetInvestmentsForUser()
        {
            CreateFakeInvestmentContext();

            InvestmentController controller = new InvestmentController(db);

            // get the investments for userId = 1
            List<Investment> investments = controller.Get(1);

            // Asserts
            Assert.IsNotNull(investments);
            Assert.AreEqual(2, investments.Count());
        }

        [TestMethod]
        public void GetInvestmentDetailsForInvestmentId()
        {
            CreateFakeInvestmentContext();

            InvestmentController controller = new InvestmentController(db);

            // get the investments for userId = 1
            InvestmentDetail2 investmentDetails = controller.GetInvestmentDetail(1);

            // Asserts
            Assert.IsNotNull(investmentDetails);
            Assert.AreEqual(5, investmentDetails.Shares);
            Assert.AreEqual(14, investmentDetails.CostBasisPerShare);
            Assert.AreEqual(55, investmentDetails.CurrentPrice);
            Assert.AreEqual(InvestmentHelper.GetCurrentValue(investmentDetails.Shares, investmentDetails.CurrentPrice), investmentDetails.CurrentValue);
            Assert.AreEqual(InvestmentHelper.GetTerm(investmentDetails.PurchaseDate), investmentDetails.Term);
            Assert.AreEqual(InvestmentHelper.GetNetGainLoss(investmentDetails.CurrentValue, investmentDetails.Shares, investmentDetails.CostBasisPerShare), investmentDetails.NetGainLoss);
        }

        private void CreateFakeInvestmentContext()
        {
            if (this.db == null)
                this.db = new InvestmentContext();

            // clear out any old data first
            ClearFakeInvestmentData();

            // add a set of investments
            db.Investments.Add(new Investment { Id = 1, Name = "Investment A", UserId = 1 });
            db.Investments.Add(new Investment { Id = 2, Name = "Investment B", UserId = 1 });
            db.Investments.Add(new Investment { Id = 3, Name = "Investment A", UserId = 2 });
            db.Investments.Add(new Investment { Id = 4, Name = "Investment C", UserId = 2 });
            db.Investments.Add(new Investment { Id = 5, Name = "Investment D", UserId = 3 });

            // add a set of investmentdetails
            db.InvestmentDetails.Add(new InvestmentDetail { Id = 1, InvestmentId = 1, Shares = 5, CostBasisPerShare = 14, CurrentPrice = 55, PurchaseDate = DateTime.UtcNow });
            db.InvestmentDetails.Add(new InvestmentDetail { Id = 2, InvestmentId = 2, Shares = 10, CostBasisPerShare = 3.50, CurrentPrice = 13.50, PurchaseDate = DateTime.UtcNow });
            db.InvestmentDetails.Add(new InvestmentDetail { Id = 3, InvestmentId = 3, Shares = 20, CostBasisPerShare = 12.75, CurrentPrice = 9.70, PurchaseDate = DateTime.UtcNow });
            db.InvestmentDetails.Add(new InvestmentDetail { Id = 4, InvestmentId = 4, Shares = 25, CostBasisPerShare = 33, CurrentPrice = 38, PurchaseDate = DateTime.UtcNow });
            db.InvestmentDetails.Add(new InvestmentDetail { Id = 5, InvestmentId = 5, Shares = 40, CostBasisPerShare = 45.90, CurrentPrice = 80.45, PurchaseDate = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc) });

            db.SaveChanges();
        }
        private void ClearFakeInvestmentData()
        {
            foreach (Investment investment in db.Investments)
                db.Investments.Remove(investment);

            foreach (InvestmentDetail investmentDetail in db.InvestmentDetails)
                db.InvestmentDetails.Remove(investmentDetail);

            db.SaveChanges();
        }
    }
}
