namespace TradingApp.PerformanceApi.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TradingApp.PerformanceApi.Models;
    using TradingApp.PerformanceApi.Services;

    /// <summary>
    /// Logic for the investments resource endpoints.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class InvestmentsController : Controller
    {
        private readonly ILogger<InvestmentsController> logger;
        private readonly IPortfolioService portfolio;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentsController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="portfolio">The portfolio access service.</param>
        public InvestmentsController(ILogger<InvestmentsController> logger, IPortfolioService portfolio)
        {
            this.logger = logger;
            this.portfolio = portfolio;
        }

        /// <summary>
        /// Get all investment records.
        /// </summary>
        /// <param name="userId">(Optional) Filter investments by a specific user.</param>
        /// <returns>The matching investment records.</returns>
        [HttpGet]
        public IEnumerable<InvestmentSummary> Get(int? userId = null)
        {
            this.logger.LogInformation($"GET /investments - (userId: {userId})");

            return userId.HasValue
                ? this.portfolio.GetInvestmentsByUserId(userId.Value)
                : this.portfolio.GetInvestments();
        }

        /// <summary>
        /// Get the performance details of an investment.
        /// </summary>
        /// <param name="id">The investment id.</param>
        /// <returns>The investment details record.</returns>
        [HttpGet]
        public ActionResult<InvestmentDetails> Details(int id)
        {
            var details = this.portfolio.GetInvestmentDetails(id);

            if (details == null)
            {
                return this.NotFound();
            }

            return details;
        }
    }
}
