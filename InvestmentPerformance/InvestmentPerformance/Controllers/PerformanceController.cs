using InvestmentPerformance.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentPerformance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerformanceController : ControllerBase
    {
        private IInvestmentService _investmentService;
        private ILogger<PerformanceController> _logger;

        public PerformanceController(IInvestmentService investmentService, ILogger<PerformanceController> logger)
        {
            _investmentService = investmentService;
            _logger = logger;
        }

        /// <summary>
        /// if nothing returned, then return 404 for not found.
        ///  otherwise return 200.
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="investment"></param>
        /// <returns></returns>
        [HttpGet("user/{userGuid}/investments/{investment}")]
        public async Task<IActionResult> Get(Guid userGuid, string investment)
        {
            var details = await _investmentService.GetInvestmentPerformanceDetails(userGuid, investment);
            if (details == null) return NotFound(null);
            return Ok(details);
        }
        /// <summary>
        ///  if nothing returned, then return 404 for not found.
        ///  otherwise return 200.
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        [HttpGet("user/{userGuid}/investments")]
        public async Task<IActionResult> Get(Guid userGuid)
        {
            var investmentList = await _investmentService.GetInvestmentList(userGuid);
            if (!investmentList.Any())  return NotFound(null);

            return Ok(investmentList); 
        }
          
    }
}
