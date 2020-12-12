using System;
using System.Collections.Generic;
using System.Linq;
using InvestmentPerformance.WebAPI.Models;
using InvestmentPerformance.WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformance.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly IInvestmentPerformanceRepository _repository;
        private readonly ILogger _logger;

        public InvestmentsController(IInvestmentPerformanceRepository repository, ILogger<InvestmentsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Gets a list of all current investments for a user.
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        [HttpGet("{userId:int}")]
        public ActionResult<List<UserInvestmentsResponse>> GetAllUserInvestments(int userId)
        {
            _logger.LogInformation("Getting all user investments.");

            try
            {
                List<UserInvestmentsResponse> response = new List<UserInvestmentsResponse>();
                var results = _repository.GetAllInvestmentsForUser(userId);

                foreach(var queryResult in results)
                {
                    response.Add(new UserInvestmentsResponse()
                    {
                        InvestmentId = queryResult.InvestmentId,
                        Name = queryResult.Stock.CompanyName
                    });
                }

                return Ok(response);
                
            }
            catch(Exception ex)
            {
                // TODO: log exception and return an InternalServerError
                _logger.LogError(string.Format("An exception occurred while retrieving user investments. Exception: {0}", ex));
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gets the details of a specific investment for a user.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId:int}/{investmentId:int}")]
        public ActionResult<UserInvestmentsResponse> GetUserInvestmentDetails(int userId, int investmentId)
        {
            _logger.LogInformation("Getting user investment details.");

            try
            {
                var result = _repository.GetInvestmentDetailsById(userId, investmentId);

                if (result != null)
                {
                    return Ok(
                        new UserInvestmentsResponse()
                        {
                            ShareCount = result.ShareCount,
                            CostBasis = result.CostBasis,
                            CurrentPrice = result.Stock.CurrentPrice,
                            Term = result.PurchaseDate.AddYears(1) > DateTime.Now ? "Short Term" : "Long Term",
                            TotalGain = (result.Stock.CurrentPrice - result.CostBasis) * result.ShareCount
                        }                    
                    );
                }
                else
                {
                    return Ok(new UserInvestmentsResponse());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("An exception occurred while retrieving user investment details. Exception: {0}", ex));
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
