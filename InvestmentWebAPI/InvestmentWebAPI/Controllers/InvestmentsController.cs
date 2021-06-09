using AutoMapper;
using Investment.API.Models;
using Investment.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Investment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly IInvestmentRepository _repo;
        private readonly IMapper _mapper;

        public InvestmentsController(IInvestmentRepository repo,
            IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvestmentModel>> GetInvestments()
        {
            var investmentsFromRepo = _repo.GetInvestments();
            return Ok(_mapper.Map<IEnumerable<InvestmentModel>>(investmentsFromRepo));
        }

        [HttpGet("{investmentId:long}")]
        public ActionResult<IEnumerable<UserInvestmentModel>> GetUserInvestments(long investmentId)
        {
            var investment = _repo.GetInvestment(investmentId);

            if (investment == null)
            {
                // The username wasn't found, so return HTTP 404
                return NotFound();
            }

            return Ok(_mapper.Map<UserInvestmentDetailsModel>(investment));
        }
    }
}
