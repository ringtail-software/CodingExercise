using CodingExercise.BLL;
using CodingExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace CodingExercise.Service.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class InvestmentController : Controller
    {
        private IInvestmentLogic _investmentLogic;
        public InvestmentController(IInvestmentLogic investmentLogic)
        {
            _investmentLogic = investmentLogic;
        }
        /// <summary>
        /// Returns a list of current investments for the user.
        /// </summary>
        /// <remarks>
        /// 
        /// Sample Request:
        /// api/Investment/1
        /// 
        /// </remarks>
        /// <param name="userId">Id of the user.</param>
        /// <returns></returns>
        [HttpGet("{userId:int}")]
        [Produces(typeof(Result<LinkCollectionWrapper<Investment>>))]
        public Result<LinkCollectionWrapper<Investment>> List(int userId)
        {
            return _investmentLogic.GetInvestmentsForUser(userId);
        }

        /// <summary>
        /// Returns details for a user's investment.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// api/Investment/1/Details/1001
        /// </remarks>
        /// <param name="userId">Id of the user.</param>
        /// <param name="investmentId">Id of the users investment</param>
        /// <returns></returns>
        [HttpGet("{userId:int}/Details/{investmentId:int}")]
        [ProducesResponseType(typeof(Result<InvestmentDetail>), 200)]
        public Result<InvestmentDetail> Details(int userId, int investmentId)
        {
            return _investmentLogic.GetInvestmentDetail(userId, investmentId);
        }
    }
}
