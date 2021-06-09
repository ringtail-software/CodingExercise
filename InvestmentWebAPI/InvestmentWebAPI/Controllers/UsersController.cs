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
    public class UsersController : ControllerBase
    {
        private readonly IInvestmentRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IInvestmentRepository repo,
            IMapper mapper)
        {
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> GetUsers()
        {
            var usersFromRepo = _repo.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserModel>>(usersFromRepo));
        }


        [HttpGet("{userName:guid}")]
        public ActionResult<IEnumerable<UserInvestmentModel>> GetUserInvestments(Guid userName)
        {
            var user = _repo.GetUser(userName);

            if (user == null)
            {
                // The username wasn't found, so return HTTP 404
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<UserInvestmentModel>>(user.Investments));
        }
    }
}