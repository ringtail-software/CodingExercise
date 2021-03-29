using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuixInvestments.Data;
using NuixInvestments.MiddleWare.Data.POCO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NuixInvestments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly ILogger<FinanceController> Logger;
        protected readonly IMiddleWare MiddleWare;

        public FinanceController(ILogger<FinanceController> logger, IMiddleWare middleWare)
        {
            Logger = logger;
            MiddleWare = middleWare;
        }

        [HttpGet("{userid}")]
        public IEnumerable<UserInvestment> Get(int userId)
        {
            Logger.LogDebug("Entered FinanceController.Get(int)");

            var returnData = MiddleWare.GetAllInvestmentsForUser(userId);

            return returnData;
        }

        [HttpGet("details/{userid}/{investmentId}")]
        public UserInvestment Details(int userId, int investmentId)
        {
            Logger.LogDebug("Entered FinanceController.Details(int, int)");

            var returnData = MiddleWare.GetSingleInvestmentForUser(userId, investmentId);

            return returnData;
        }

    }
}
