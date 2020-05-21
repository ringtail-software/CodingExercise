namespace TradingApp.PerformanceApi.Models
{
    /// <summary>
    /// Summarized information regarding an investment.
    /// </summary>
    public class InvestmentSummary
    {
        /// <summary>
        /// Gets the investment id.
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// Gets the id of the user that owns the investment.
        /// </summary>
        public int UserId { get; internal set; }

        /// <summary>
        /// Gets the investment name.
        /// </summary>
        public string Name { get; internal set; }
    }
}
