using InvestmentPerformance.WebApi.Models;
using InvestmentPerformance.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPerformance.WebApi.Controllers
{
    [Route("api/users/{userId:int}/investments")]
    [ApiController]
    public class UserInvestmentsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IInvestmentsRepository _service;

        public UserInvestmentsController(ILogger<UserInvestmentsController> logger, IInvestmentsRepository service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Investment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserInvestmentsAsync(int userId)
        {
            try
            {
                var investments = await _service.GetInvestmentsAsync(userId);

                if (investments == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(investments);
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
