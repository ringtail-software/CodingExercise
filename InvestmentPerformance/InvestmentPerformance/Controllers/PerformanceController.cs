using System;
using System.Collections.Generic;
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

        [HttpGet("user/{userId}/investments/{investment}")]
        public InvestmentDetails Get(Guid userGuid, string investment)
        {
            //if null returned, then return 404 for not found. for the guid.
            //otherwise return 200.
            return _investmentService.GetInvestmentPerformanceDetails(userGuid, investment);
        }

        [HttpGet("user/{userId}/investments")]
        public IEnumerable<Investment> Get(Guid userGuid)
        {
            //if null returned, then return 404 for not found. for the guid.
            //otherwise return 200.
            return _investmentService.GetInvestmentList(userGuid);
        }
          
    }
}
