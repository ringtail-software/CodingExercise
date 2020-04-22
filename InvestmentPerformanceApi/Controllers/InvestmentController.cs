using InvestmentPerformanceApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InvestmentPerformanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentRepository _investmentRepository;

        public InvestmentController(IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        [HttpGet]
        [Route("investments/{userId}")]
        public IActionResult GetInvestmentsByUser(int userId)
        {
            var investments = _investmentRepository.GetInvestmentsByUser(userId);

            if (investments == null || investments.Count() < 1)
            {
                return NotFound();
            }

            return Ok(investments);
        }

        [HttpGet]
        [Route("investmentdetail/{investmentId}")]
        public IActionResult GetInvestmentDetail(int investmentId)
        {
            var investmentPerformance = _investmentRepository.GetInvestmentDetail(investmentId);

            if (investmentPerformance == null)
            {
                return NotFound();
            }

            return Ok(investmentPerformance);
        }
    }
}
