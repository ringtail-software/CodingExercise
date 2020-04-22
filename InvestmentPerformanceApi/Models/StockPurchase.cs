using System;

namespace InvestmentPerformanceApi.Models
{
    public class StockPurchase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Shares { get; set; }
        public decimal PurchaseCostPerShare { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
