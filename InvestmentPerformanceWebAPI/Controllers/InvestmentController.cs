using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using InvestmentPerformanceWebAPI.Data;
using InvestmentPerformanceWebAPI.Models;
using InvestmentPerformanceWebAPI.Helpers;

namespace InvestmentPerformanceWebAPI.Controllers
{
    public class InvestmentController : ApiController
    {
        private IInvestmentContext db = null;

        public InvestmentController()
        {
            this.db = new InvestmentContext(); 
            PopulateFakeInvestmentData();
        }

        public InvestmentController(IInvestmentContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Gets a list of all the investments
        /// </summary>
        /// <returns>a list of investments</returns>
        public List<Investment> Get()
        {
            List<Investment> investments = db.Investments.ToList();

            if (investments == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return investments;
        }

        /// <summary>
        /// Gets a list of investments for the given userId
        /// </summary>
        /// <param name="id">User Id to retrieve investments for</param>
        /// <returns>a list of investments for the user</returns>
        public List<Investment> Get(int id)
        {
            List<Investment> investments = db.Investments.Where(x => x.UserId == id).ToList();

            if (investments == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return investments;
        }

        /// <summary>
        /// Gets the investment details for the given investment Id
        /// </summary>
        /// <param name="investmentId">The identifier for the investment</param>
        /// <returns>investment details</returns>
        [Route("api/Investment/GetInvestmentDetail/{investmentId:int}")]
        [HttpGet]
        public InvestmentDetail2 GetInvestmentDetail(int investmentId)
        {
            InvestmentDetail investmentDetail = db.InvestmentDetails.Where(x => x.InvestmentId == investmentId).FirstOrDefault();

            if (investmentDetail == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            InvestmentDetail2 returnDetail = new InvestmentDetail2();

            returnDetail.Id = investmentDetail.Id;
            returnDetail.InvestmentId = investmentDetail.InvestmentId;
            returnDetail.CostBasisPerShare = investmentDetail.CostBasisPerShare;
            returnDetail.CurrentPrice = investmentDetail.CurrentPrice;
            returnDetail.Shares = investmentDetail.Shares;
            returnDetail.PurchaseDate = investmentDetail.PurchaseDate;
            returnDetail.CurrentValue = InvestmentHelper.GetCurrentValue(returnDetail.Shares, returnDetail.CurrentPrice);
            returnDetail.Term = InvestmentHelper.GetTerm(returnDetail.PurchaseDate);
            returnDetail.NetGainLoss = InvestmentHelper.GetNetGainLoss(returnDetail.CurrentValue, returnDetail.Shares, returnDetail.CostBasisPerShare);

            return returnDetail;
        }

        private void PopulateFakeInvestmentData()
        {
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
        protected override void Dispose(bool disposing)
        {
            if (this.db is IDisposable)
            {
                ((IDisposable)db).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
