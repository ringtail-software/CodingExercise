namespace TradingApp.PerformanceApi.Models
{
    using System;

    /// <summary>
    /// The performance details for an investment.
    /// </summary>
    public class InvestmentDetails : InvestmentSummary
    {
        /// <summary>
        /// Gets the number of shares.
        /// </summary>
        public int Shares { get; internal set; }

        /// <summary>
        /// Gets the cost basis per share.
        /// This is the price of 1 share of stock at the time it was purchased.
        /// </summary>
        public decimal CostBasis { get; internal set; }

        /// <summary>
        /// Gets the current price per share.
        /// This is the current price of 1 share of the stock.
        /// </summary>
        public decimal CurrentPrice { get; internal set; }

        /// <summary>
        /// Gets the current investment value.
        /// This is the number of shares multiplied by the current price per share.
        /// </summary>
        public decimal CurrentValue => this.Shares * this.CurrentPrice;
    }
}
