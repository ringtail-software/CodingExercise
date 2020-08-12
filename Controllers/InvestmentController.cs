using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using KrummertNuix.DatabaseModels;
using KrummertNuix.Repositories;
using KrummertNuix.ViewModels;

namespace KrummertNuix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentController : ControllerBase
    {
        private readonly ILogger<InvestmentController> _logger;
        private readonly UserInvestmentRepository _Repository;

        public InvestmentController(ILogger<InvestmentController> logger, UserInvestmentRepository repository)
        {
            _logger = logger;
            _Repository = repository;
        }
        
        [HttpGet]
        public ObjectResult Get([FromQuery] Guid userId, [FromQuery] Guid? investmentId)
        {
            return !investmentId.HasValue ? 
                GetByUserId(userId) : GetByUserIdAndInvestmentId(userId, investmentId.Value);

        }

        // As an API user, I want to be able to query the list of investments for a user.  The query should return 
        // the investment id and name.
        private ObjectResult GetByUserId(Guid userId)
        {
            try
            {
                _logger.LogInformation("InvestmentController was called with " + userId);
                return Ok(_Repository.Get(userId).Select(m => new InvestmentsByUserModel(){ 
                    Id = m.Id, 
                    Name = m.Name
                }).ToList());
            }
            catch(Exception ex)
            {

                _logger.LogError("InvestmentController errored: " + ex);
                return BadRequest(ex); 
            }
        }
        //As an API user, I want to be able to query the details of a specific investment for a user.  
        // The query should return number of shares, cost basis per share, current value, current price, term, and total gain/loss.
        private ObjectResult GetByUserIdAndInvestmentId(Guid userId, Guid investmentId)
        {
            try
            {
                _logger.LogInformation("InvestmentController was called with " + userId + " and " + investmentId);
                
                var temp = _Repository.Get(userId, investmentId);
                var returnObj = new InvestmentModel() 
                {
                    NumberOfShares = temp.StocksAtPurchase.QtySharesPurchased,
                    CostBasisPerShare = temp.StocksAtPurchase.PricePerShare,
                    CurrentValue = temp.StocksAtPurchase.QtySharesPurchased
                     * temp.StocksAtPurchase.StocksAtCurrent.PricePerShare,
                    CurrentPrice = temp.StocksAtPurchase.StocksAtCurrent.PricePerShare,
                    Term = 
                        (new TimeSpan(DateTime.Now.Ticks - temp.StocksAtPurchase.DatePurchased.Ticks).TotalDays > 365) ?
                        "Long Term" : "Short Term",
                    TotalGainOrLoss = 
                        // Current Value
                        temp.StocksAtPurchase.QtySharesPurchased * temp.StocksAtPurchase.StocksAtCurrent.PricePerShare -
                        // Purchase Value
                        temp.StocksAtPurchase.QtySharesPurchased * temp.StocksAtPurchase.PricePerShare
                };
                
                return Ok(returnObj);
            }
            catch(Exception ex)
            {
                _logger.LogError("InvestmentController errored: " + ex);
                return BadRequest(ex); 
            }
        }
    }}
