using InvestmentAPI.Models;
using InvestmentAPI.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private IInvestmentDataService _investmentDataService;

        public InvestmentController(IInvestmentDataService investmentDataService)
        {
            _investmentDataService = investmentDataService;
        }

        // GET api/investment/id
        [HttpGet("{id}")]
        public ActionResult<List<Investment>> GetInvestmentByUserId(int userId)
        {
            var investments = _investmentDataService.GetInvestmentByUserId(userId);

            if (!investments.Any()) 
            {
                return BadRequest();
            }

            return investments;
        }

        // GET api/values/5
        [HttpGet]
        public ActionResult<InvestmentDetail> GetInvestmentDetailById(int id)
        {
            var investmentDetail = _investmentDataService.GetInvestmentDetailById(id);

            if (investmentDetail == null)
            {
                return BadRequest();
            }

            return investmentDetail;
        }
    }
}
