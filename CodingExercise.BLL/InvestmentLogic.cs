using CodingExercise.DAL;
using CodingExercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.BLL
{
    public class InvestmentLogic : IInvestmentLogic
    {
        private IHttpContextAccessor _httpContextAccessor;
        private LinkGenerator _linkGenerator;
        private IRepository _repo;
        private ILogger _logger;
        public InvestmentLogic(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator, IRepository repo, ILogger<InvestmentLogic> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _linkGenerator = linkGenerator;
            _repo = repo;
            _logger = logger;
        }
        public Result<InvestmentDetail> GetInvestmentDetail(int userId, int investmentId)
        {
            var result = new Result<InvestmentDetail>()
            {
                Success = true
            };
            try
            {
                var data = _repo.GetUserInvestmentDetail(userId, investmentId);

                /*
                 *  The query should return number of shares, cost basis per share, current value, current price, term, and total gain/loss.
                 * Cost basis per share: this is the price of 1 share of stock at the time it was purchased

                 * Current value: this is the number of shares multiplied by the current price per share

                 * Current price: this is the current price of 1 share of the stock

                 * Term: this is how long the stock has been owned. <=1 year is short term, >1 year is long term

                 * Total gain or loss: this is the difference between the current value, and the amount paid for all shares when they were purchase
                 */
                result.Data = new InvestmentDetail
                {
                    Id = data.Id,
                    Name = data.Name,
                    CostBasisPerShare = $"${data.PriceAtPurchase}",
                    CurrentPrice = $"${data.CurrentPrice}",
                    CurrentValue = $"{(data.NumShares * data.CurrentPrice)}",
                    Links = new List<Link>()
                    {
                        new Link(_linkGenerator.GetUriByAction(_httpContextAccessor.HttpContext, "Details", "Investment", values: new { userId, investmentId }),"Self", "GET")
                    },
                    NumShares = data.NumShares,
                    TotalGainLoss = $"{(data.CurrentPrice >= data.PriceAtPurchase ? "+" : "-")}${(data.CurrentPrice > data.PriceAtPurchase ? data.CurrentPrice - data.PriceAtPurchase : data.PriceAtPurchase - data.CurrentPrice) * data.NumShares}",
                    Term = Convert.ToInt32((DateTime.Now - data.PurchaseDate).Days / 365) > 1 ? "Long" : "Short"
                };
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occured while retrieving the requested data";
                _logger.LogError(ex, $"An error occured while retrieving the requested InvestmentDetail. User Id: {userId}. Investment Id: {investmentId}");
            }
            return result;
        }

        public Result<LinkCollectionWrapper<Investment>> GetInvestmentsForUser(int userId)
        {
            var result = new Result<LinkCollectionWrapper<Investment>>() 
            {
                Success = true
            };
            try
            {
                result.Data = new LinkCollectionWrapper<Investment>()
                {
                    Values = _repo.GetUserInvestments(userId).Select(data => new Investment
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Links = new List<Link>()
                        {
                            new Link(_linkGenerator.GetUriByAction(_httpContextAccessor.HttpContext, "Details", "Investment", values: new { userId, investmentId = data.Id }),"Details", "GET")
                        }
                    }),
                    Links = new List<Link>()
                    {
                        new Link(_linkGenerator.GetUriByAction(_httpContextAccessor.HttpContext, "List", "Investment", values: userId), "Self", "GET")
                    }
                };
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occured while retrieving the requested data";
                _logger.LogError(ex, $"An error occured while retrieving the requested Investment list. User Id: {userId}");
            }
            return result;
        }
    }
}
