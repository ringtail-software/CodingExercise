using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentPerformance.Api.Models
{
    public class InvestmentDetails
    {
        public float Shares { get; set; }
        public decimal CostBasis { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Term { get; set; }
        public decimal TotalGainLoss => (CurrentPrice * (decimal)Shares) - CostBasis;
    }
}
