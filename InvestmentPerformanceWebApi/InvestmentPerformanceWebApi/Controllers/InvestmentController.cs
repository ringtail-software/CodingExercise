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

        [HttpGet]
        public async Task<List<InvestmentSummary>> Get()
        {
            return await _dal.GetUserInvestmentSummaries(1);
        }

        [HttpGet("{investmentId}")]
        public async Task<InvestmentDetail> Get(int investmentId)
        {
            return await _investmentManager.GetInvestmentDetail(1, investmentId);
        }
    }
}
