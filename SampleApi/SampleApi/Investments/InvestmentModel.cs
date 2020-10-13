using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Investments
{
    /// <summary> 
    ///     Investment details as it pertains to a user 
    ///     Assumption: An Investment represents single transaction
    ///  </summary>
    public class Investment
    {
        public int InvestmentId { get; set; }
        public string InvestmentName { get; set; }

        // assumption: it's possible to own fractions of a share
        public decimal SharesOwned { get; set; }

        /// <summary> this is the current price of 1 share of the stock </summary>
        public decimal CurrentPricePerShare { get; set; }

        /// <summary> this is the price of 1 share of stock at the time it was purchased </summary>
        public decimal CostBasisPerShare { get; set; }

        /// <summary> this is the number of shares multiplied by the current price per share </summary>
        public decimal CurrentValue { get { return CurrentPricePerShare * SharesOwned; } }

        /// <summary> this is how long the stock has been owned.  <=1 year is short term, >1 year is long term </summary>
        public ShareTerm Term { get; set; }

        /// <summary> this is the difference between the current value, and the amount paid for all shares when they were purchased </summary>
        public decimal TotalGainLoss { get { return CurrentValue - (SharesOwned * CostBasisPerShare); } }
    }

    /// <summary> Investments list item </summary>
    public class InvestmentHeader
    {
        public int InvestmentId { get; set; }        
        public string InvestmentName { get; set; }
    }

    /// <summary> Length of time shares have been owned </summary>
    public enum ShareTerm
    {
        ShortTerm,
        LongTerm
    }
}
