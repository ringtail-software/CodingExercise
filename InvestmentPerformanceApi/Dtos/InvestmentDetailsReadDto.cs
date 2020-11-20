using System;

namespace InvestmentPerformanceApi.Dtos
{
    public class InvestmentDetailsReadDto
    {
        public int InvestmentId { get; set; }
        public decimal CostBasis { get; set; }
        public int Shares { get; set; }
        public decimal CurrentValue => Shares * CurrentPrice;
        public decimal CurrentPrice { get; set; }
        public bool ShortTerm => PurchaseDate.CompareTo(DateTime.UtcNow.AddYears(-1)) < 0;
        public DateTime PurchaseDate { get; set; }
        public string CompanyName { get; set; }

    }
}
