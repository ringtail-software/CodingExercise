using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentPerformance.Models;
using InvestmentPerformance.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPerformance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerformanceController : ControllerBase
    {
        private IInvestmentService _investmentService;

        public PerformanceController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
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
