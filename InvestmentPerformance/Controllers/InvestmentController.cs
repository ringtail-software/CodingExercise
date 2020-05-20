using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentPerformance.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformance.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class InvestmentController : ControllerBase
    {
        private readonly ILogger<InvestmentController> _logger;
        private readonly IInvestmentService _investmentService;

        public InvestmentController(ILogger<InvestmentController> logger, IInvestmentService investmentService)
        {
            _logger = logger;
            _investmentService = investmentService;
        }

        [HttpGet]
        [Route("user/{userId}/investments")]
        public IActionResult GetUserInvestments(Guid userId)
        {
            //I'm assuming you don't want me to handroll an auth solution, 
            //so we can assume the request is vetted and userId can't be spoofed.
            _logger.LogInformation($"GET GetUserInvestments({userId})");
            var currentInvestments = _investmentService.GetCurrentInvestments(userId);
            if (currentInvestments.Any())
                return Ok(currentInvestments);
            else
            {
                _logger.LogWarning($"404 Returned for GetUserInvestments({userId})");
                return NotFound();
            }
        }

        [HttpGet]
        [Route("user/{userId}/investment/{investmentId}")]
        public IActionResult GetInvestment(Guid userId, Guid investmentId)
        {
            //I'm assuming you don't want me to handroll an auth solution, 
            //so we can assume the request is vetted and userId can't be spoofed.
            _logger.LogInformation($"GET GetInvestment({userId}, {investmentId})");
            var utcNow = DateTime.UtcNow;
            var investment = _investmentService.GetInvestment(userId, investmentId, utcNow);
            if (investment != null)
                return Ok(investment);
            else
            {
                _logger.LogWarning($"404 Returned for GetInvestment({userId}, {investmentId})");
                return NotFound();
            }
        }
    }
}
