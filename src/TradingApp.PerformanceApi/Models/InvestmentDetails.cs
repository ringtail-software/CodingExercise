namespace TradingApp.PerformanceApi.Models
{
    using System;
    using TradingApp.PerformanceApi.Enums;

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
        /// Gets the original purchase date.
        /// </summary>
        public DateTime PurchaseDate { get; internal set; }

        /// <summary>
        /// Gets the term.
        /// This is how long the stock has been owned. <=1 year is short term, >1 year is long term.
        /// </summary>
        public Term Term => (DateTime.Now - this.PurchaseDate).TotalDays > 365 ? Term.Long : Term.Short;

        /// <summary>
        /// Gets the current investment value.
        /// This is the number of shares multiplied by the current price per share.
        /// </summary>
        public decimal CurrentValue => this.Shares * this.CurrentPrice;

        /// <summary>
        /// Gets the total gain or loss.
        /// This is the difference between the current value, and the amount paid for all shares when they were purchased.
        /// </summary>
        public decimal TotalGain => this.CurrentValue - (this.CostBasis * this.Shares);
    }
}
