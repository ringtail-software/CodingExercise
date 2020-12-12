using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentPerformance.Data.Entities
{
    public class UserInvestment
    {
        [Key]
        public int InvestmentId { get; set; }
        public int UserId { get; set; }
        public string TickerSymbol { get; set; }
        public decimal ShareCount { get; set; }
        public decimal CostBasis { get; set; }
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("TickerSymbol")]
        public Stock Stock { get; set; }
    }
}
