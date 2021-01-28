using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuixApi.Models;
using NuixApi.BusinessLogic;

namespace NuixApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestmentsController : ControllerBase
    {
        private readonly NuixContext _context;

        public InvestmentsController(NuixContext context)
        {
            _context = context;
       
        }


        // GET: api/Investments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investment>>> GetInvestments()
        {
            //Return all of the id's and name in a list.

            return await _context.Investments.ToListAsync();
        }

  
        // GET: api/Investments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvestmentOutput>> GetInvestmentDetails(int id)
        {
            var businessLogic = new NuixBusinessLogic(_context);

            //Call the business logic to get the results. 
            var investmentDetails=  await businessLogic.ReturnInvestmentDetailedView(id);

            //If we don't find any investment for the id return a 404 (not found)
            if (investmentDetails == null)
            {
                return NotFound();
            }

            return  investmentDetails;
        }
    }
}
