using InvestmentPerformance.WebApi.Models;
using InvestmentPerformance.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace InvestmentPerformance.WebApi.Controllers
{
    [Route("api/users/{userId:int}/investments/{investmentId:int}/details")]
    [ApiController]
    public class UserInvestmentDetailsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IInvestmentDetailsRepository _service;

        public UserInvestmentDetailsController(ILogger<UserInvestmentDetailsController> logger, IInvestmentDetailsRepository service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(InvestmentDetails), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserInvestmentDetailsAsync(int userId, int investmentId)
        {
            try
            {
                var investmentDetails = await _service.GetInvestmentDetailsAsync(userId, investmentId);

                if (investmentDetails == null)
                {
                    return NotFound();
                }   
                else
                {
                    return Ok(investmentDetails);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
