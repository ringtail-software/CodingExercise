using System;
namespace InvestmentPerformance.API.Application.Models
{
    /// <summary>
    /// View Model that holds only investment details
    /// </summary>
    public class InvestmentDetails
    {
        public InvestmentDetails() { }

        public int NumberOfShares { get; set; }

        public decimal CostBasisPerShare { get; set; }

        public decimal CurrentValue { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal Term { get; set; }

        public string TermLength { get; set; }

        public decimal TotalGainOrLoss { get; set; }
    }
}
