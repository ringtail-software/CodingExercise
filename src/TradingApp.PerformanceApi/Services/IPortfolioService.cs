namespace TradingApp.PerformanceApi.Services
{
    using System.Collections.Generic;
    using TradingApp.PerformanceApi.Models;

    /// <summary>
    /// A service for managing investment portfolio assets.
    /// </summary>
    public interface IPortfolioService
    {
        /// <summary>
        /// Get a collection of investment summaries.
        /// </summary>
        /// <returns>A collection of investment summaries.</returns>
        ICollection<InvestmentSummary> GetInvestments();

        /// <summary>
        /// Get a collection of investment summaries for a specific user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>A collection of investment summaries.</returns>
        ICollection<InvestmentSummary> GetInvestmentsByUserId(int userId);

        /// <summary>
        /// Get the performance details for an investment.
        /// </summary>
        /// <param name="id">The investment id.</param>
        /// <returns>The performance details.</returns>
        InvestmentDetails GetInvestmentDetails(int id);
    }
}
