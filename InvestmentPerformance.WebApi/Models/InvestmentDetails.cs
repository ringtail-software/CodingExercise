using System;

namespace InvestmentPerformance.WebApi.Models
{
    public class InvestmentDetails
    {
        public int Shares { get; set; }

        public DateTime DatePurchased { get; set; }

        public decimal CostBasis { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal CurrentValue => Shares * CurrentPrice;

        public decimal TotalGain => (CurrentPrice - CostBasis) * Shares;

        public string Term => DatePurchased.CompareTo(DateTime.UtcNow.AddYears(-1)) < 0 ? Terms.LongTerm : Terms.ShortTerm;
    }
}
