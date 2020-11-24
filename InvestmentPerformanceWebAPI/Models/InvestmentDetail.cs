using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentPerformanceWebAPI.Models
{
    /// <summary>
    /// Holds the details for an investment
    /// </summary>
    public class InvestmentDetail
    {
        /// <summary>
        /// The investment detail id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The investement Id
        /// </summary>
        public int InvestmentId { get; set; }
        /// <summary>
        /// The number of shares
        /// </summary>
        public int Shares { get; set; }
        /// <summary>
        /// The price of 1 share of stock at the time it was purchased
        /// </summary>
        public double CostBasisPerShare { get; set; }
        /// <summary>
        /// The number of shares * the current price
        /// </summary>
        //public double CurrentValue { get; set; }
        /// <summary>
        /// The current price of 1 share of stock 
        /// </summary>
        public double CurrentPrice { get; set; }
        /// <summary>
        /// How long the stock was owned; <=1 year is short term, >1 year is long term
        /// </summary>
        //public byte Term { get; set; }
        /// <summary>
        /// The difference between the current value and the amount paid for all shares when they were purchased
        /// </summary>
        //public double NetGainLoss { get; set; }
        /// <summary>
        /// The purchase date of the stock, used to calculate Term
        /// </summary>
        public DateTime PurchaseDate { get; set; }
    }
}