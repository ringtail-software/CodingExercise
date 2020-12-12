using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestmentPerformance.Data.Entities
{
    public class Stock
    {
        [Key]
        public string TickerSymbol { get; set; }
        public string CompanyName { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Open { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public int Volume { get; set; }
        public ICollection<UserInvestment> UserInvestments { get; set; }
    }
}
