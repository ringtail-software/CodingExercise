// All data requested for investment analysis

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    public class Analysis
    {
        // The initial purchase price of the investment
        public decimal CostBasis { get; set; }

        // Number of shares purchased
        public int Quantity { get; set; }

        // Number of shares (Quantity) multiplied by current price (CurrentPrice)
        public decimal CurrentValue { get; set; }

        // The current price of the stock
        public decimal CurrentPrice { get; set; }

        // Number of days since stock was purchased
        public int TermInDays { get; set; }

        // "Long" of "Short" investment type
        public string TermDesc { get; set; }

        // CurrentValue minus value at time of purchase (Quantity multliplied by CostBasis)
        public decimal NetGain { get; set; }
    }
}
