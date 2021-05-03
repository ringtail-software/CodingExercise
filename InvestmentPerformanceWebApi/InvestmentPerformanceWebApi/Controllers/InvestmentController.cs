using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentPerformanceWebApi.ApiModels;
using InvestmentPerformanceWebApi.Domain;
using InvestmentPerformanceWebApi.Domain.Models;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly InvestmentManager _investmentManager;
        private readonly InvestmentDal _dal;

        public InvestmentController(ILogger<InvestmentController> logger, InvestmentManager investmentManager, InvestmentDal dal)
        {
            _logger = logger;
            _investmentManager = investmentManager;
            _dal = dal;
        }

        [HttpGet("{userId}")]
        public async Task<List<InvestmentSummary>> Get(int userId)
        {
            return await _dal.GetUserInvestmentSummaries(userId);
        }

        [HttpGet("{userId}/{investmentId}")]
        public async Task<ActionResult<InvestmentDetail>> Get(int userId, int investmentId)
        {
            var result = await _investmentManager.GetInvestmentDetail(userId, investmentId);
            return result == null ? (ActionResult<InvestmentDetail>) NotFound() : Ok(result);
        }
    }
}
