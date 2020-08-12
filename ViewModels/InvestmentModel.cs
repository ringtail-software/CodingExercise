// The query should return number of shares, cost basis per share, current value, 
// current price, term, and total gain/loss.
using System;

namespace KrummertNuix.ViewModels
{
    public class InvestmentModel
    {
        public int NumberOfShares { get; set; }
        // The price of 1 share of stock at the time it was purchased
        public double CostBasisPerShare { get; set; }
        // The number of shares multiplied by the current price per share
        public double CurrentValue { get; set; }
        // The current price of 1 share of the stock
        public double CurrentPrice { get; set; }
        // How long the stock has been owned.  <=1 year is short term, >1 year is long term
        public string Term { get; set; }
        // The difference between the current value, and the amount paid for all shares when they were purchased
        public double TotalGainOrLoss { get; set; }
    }
}