using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentPerformance.API.Application.Models;
using InvestmentPerformance.API.Application.Services.Interfaces;
using InvestmentPerformance.Domain.AggregatesModel;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPerformance.API.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentsController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        /// <summary>
        /// Returns all investments (not for user but for my/your own use)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investment>>> GetAllInvestmentsAsync()
        {
            var investments = await _investmentService.GetAllInvestmentsAsync();
            return Ok(investments);
        }

        /// <summary>
        /// Returns investment for a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<UserInvestment>>> GetUserInvestmentsAsync(int userId)
        {
            var investments = await _investmentService.GetUserInvestmentsAsync(userId);
            return Ok(investments);
        }

        /// <summary>
        /// Returns investment details for a specific investment
        /// </summary>
        /// <param name="investmentId"></param>
        /// <returns></returns>
        [HttpGet("{investmentId}")]
        public async Task<ActionResult<InvestmentDetails>> GetInvestmentDetailsAsync(int investmentId)
        {
            var investmentDetails = await _investmentService.GetInvestmentDetailsAsync(investmentId);
            return Ok(investmentDetails);
        }
    }
}
