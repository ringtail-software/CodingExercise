using System;

namespace InvestmentPerformanceWebApi.Domain.Models
{
    public class Investment
    {
        public int InvestmentId { get; set; }
        public int UserId { get; set; }
        public string InvestmentName { get; set; }
        public string Symbol { get; set; }
        public int Quantity { get; set; }
        public decimal CostBasis { get; set; }
        public DateTime PurchaseTimestamp { get; set; }
    }
}
