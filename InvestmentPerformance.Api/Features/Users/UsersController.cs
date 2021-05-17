using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InvestmentPerformance.Api.Constants;
using InvestmentPerformance.Api.Features.Shared.Models;
using InvestmentPerformance.Api.Features.Users.RequestHandlers.GetUserInvestmentList;
using InvestmentPerformance.Api.Features.Users.RequestHandlers.GetUserInvestment;

namespace InvestmentPerformance.Api.Features.Users
{
    [ApiController]
    [Route("users")]
    [Authorize(AuthorizationPolicies.IsAdmin)]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{userId}/investments")]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<GetInvestmentsListModel>>> GetInvestmentsForUser(string userId) =>
            await _mediator.Send(new GetUserInvestmentListRequest(userId));

        [HttpGet("{userId}/investments/{investmentId:int}")]
        public async System.Threading.Tasks.Task<ActionResult<GetInvestmentModel>> GetInvestment(string userId, int investmentId) =>
            await _mediator.Send(new GetUserInvestmentRequest(userId, investmentId));
    }
}
