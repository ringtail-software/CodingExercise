using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentPerformanceWebApi.ApiModels
{
    public class InvestmentDetail
    {
        public int InvestmentId { get; set; }
        public string InvestmentName { get; set; }
        public decimal CostBasis { get; set; }
        public int Quantity { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal CurrentPrice { get; set; }
        public TermTypes Term { get; set; }
        public decimal TotalGain { get; set; }
    }
}
