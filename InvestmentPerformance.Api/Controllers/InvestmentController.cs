using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment.Models;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList.Models;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList;
using System.Collections.Generic;

namespace InvestmentPerformance.Api.Controllers
{
    [ApiController]
    [Route("investments")]
    [Authorize]
    public class InvestmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvestmentController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<GetInvestmentsModel>>> Get() =>
            await _mediator.Send(new GetInvestmentsRequest());

        [HttpGet("{investmentId:int}")]
        public async System.Threading.Tasks.Task<ActionResult<GetInvestmentModel>> GetInvestment(int investmentId) =>
            await _mediator.Send(new GetInvestmentRequest(investmentId));
    }
}
