using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.Models;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList;
using System.Collections.Generic;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment;

namespace InvestmentPerformance.Api.Controllers
{
    [ApiController]
    [Route("investments")]
    [Authorize]
    public class InvestmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvestmentsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<GetInvestmentsListModel>>> GetInvestments() =>
            await _mediator.Send(new GetInvestmentListRequest());

        [HttpGet("{investmentId:int}")]
        public async System.Threading.Tasks.Task<ActionResult<GetInvestmentModel>> GetInvestment(int investmentId) =>
            await _mediator.Send(new GetInvestmentRequest(investmentId));
    }
}
