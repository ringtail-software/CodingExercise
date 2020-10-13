using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApi.Investments;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly ILogger<InvestmentController> _logger;

        public InvestmentController(ILogger<InvestmentController> logger)
        {
            _logger = logger;
        }


        // assumption: the "user" accessing the API may not be the user whose investments are being queried, otherwise would get userId from claims object
        // assumption: method would have authorization, confirming user has access, returning unathorized and logging attempted access
        [HttpGet]
        [Route("Investments/{userId}")]
        public IEnumerable<InvestmentHeader> GetInvestmentsByUser(int userId)
        {
            // pseduo code: Identity/roles not implemented. Also it would be a custom attribute, possibly at controller level 
            //if (!User.IsInRole("CanAccessInvestments"))
            //{
                //_logger.LogWarning($"Unauthorized access attempt");
                //return Unauthorized();
            //}
            

            //todo: temp
            return null;
        }

        [HttpGet]
        [Route("InvestmentDetails/{investmentId")]
        public Investment GetInvestment(int investmentId)
        {
            //todo: temp
            return null;
        }
        
    }
}
