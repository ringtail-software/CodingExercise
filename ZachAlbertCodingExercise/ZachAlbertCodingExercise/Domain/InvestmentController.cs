using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ZachAlbertCodingExercise.Models;

namespace ZachAlbertCodingExercise.Domain
{
    [RoutePrefix("api/Investment")]
    public class InvestmentController : ApiController
    {
        private InvestmentManager _manager;

        //public InvestmentController()
        //{

        //}

        public InvestmentController(InvestmentManager manager)
        {
            _manager = manager;
        }

        // /api/Investment/RetrieveUserInvestments/
        [Route("RetrieveUserInvestments/{userId:int}")]
        [HttpGet]
        public async Task<List<UserInvestmentResponse>> RetrieveUserInvestments(int userId)
        {
            //_manager = new InvestmentManager(new InvestmentDal(new InvestmentContext("")));
            var investments = await  _manager.GetUserInvestments(userId);

            if (investments == null)
                return null;

            List<UserInvestmentResponse> response = new List<UserInvestmentResponse>();
            foreach (var investment in investments)
            {
                response.Add(new UserInvestmentResponse
                {
                    StockId = investment.StockId,
                    InvestmentId = investment.InvestmentId,
                    StockName = investment.StockName
                });
            }

            return response;
        }

        [Route("RetrieveUserInvestmentDetails/{userId:int}/{investmentId:int}")]
        [HttpGet]
        public async Task<List<UserInvestmentResponse>> RetrieveUserInvestmentDetails(int userId, int investmentId)
        {
            var investments = await _manager.GetUserInvestments(userId, investmentId);

            if (investments == null)
                return null;

            List<UserInvestmentResponse> response = new List<UserInvestmentResponse>();
            foreach (var investment in investments)
            {
                response.Add(new UserInvestmentResponse
                {
                    StockId = investment.StockId,
                    InvestmentId = investment.InvestmentId,
                    StockName = investment.StockName,
                    CostBasisPerShare = investment.PurchasePrice,
                    CurrentInvestmentValue = (investment.PurchaseAmount * investment.CurrentStockPrice),
                    CurrentStockPrice = investment.CurrentStockPrice,
                    Term = (DateTime.Now - investment.PurchaseDate).TotalDays < 365 ? "Short Term" : "Long Term",
                    TotalGain = (investment.PurchaseAmount * investment.CurrentStockPrice) - (investment.PurchaseAmount * investment.PurchasePrice)
                });
            }

            return response;
        }

        //RetrieveUserInvestmentDetails?id=1
    }
}