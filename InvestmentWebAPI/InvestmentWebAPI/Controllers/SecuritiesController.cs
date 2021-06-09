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
    public class SecuritiesController : ControllerBase
    {
        private readonly IInvestmentRepository _repo;
        private readonly IMapper _mapper;

        public SecuritiesController(IInvestmentRepository repo,
            IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<SecurityModel>> GetSecurities()
        {
            var securitiesFromRepo = _repo.GetSecurities();
            return Ok(_mapper.Map<IEnumerable<SecurityModel>>(securitiesFromRepo));
        }
    }
}