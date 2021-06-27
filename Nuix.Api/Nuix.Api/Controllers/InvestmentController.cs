using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nuix.Data.Dto;
using Nuix.Data.Model;
using Nuix.Data.Repository;

namespace Nuix.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InvestmentController : ControllerBase
    {
        public InvestmentController(ILogger<InvestmentController> logger, IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // The ProducesResponseType documents the return code and model that is returned.
        // This is very useful for Swagger/Swashbuckle.
        [ProducesResponseType(typeof(IEnumerable<Investment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{userName}", Name = "GetInvestmentsByUser")]
        public async Task<IActionResult> GetInvestmentsByUser(string userName)
        {
            if (await _repo.GetUserInvestments(userName) is List<Investment> {Count: > 0} investments)
            {
                return new ObjectResult(
                    _mapper.Map<IEnumerable<Investment>, IEnumerable<SimpleInvestmentDto>>(investments)
                );
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [ProducesResponseType(typeof(IEnumerable<Investment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{userName}/{investmentName}", Name = "GetInvestmentsByUserFiltered")]
        public async Task<IActionResult> GetInvestmentsByUserFiltered(string userName, string investmentName)
        {
            if (await _repo.GetUserInvestmentsFiltered(userName, investmentName) is List<Investment> { Count: > 0} investments)
                return new ObjectResult(
                    _mapper.Map<IEnumerable<Investment>, IEnumerable<DetailInvestmentDto>>(investments)
                );

            return new NotFoundResult();
        }

        private readonly IRepository _repo;
        private readonly IMapper _mapper;
    }
}