using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace InvestmentPerformance.Models
{
    public class InvestmentDetails
    {
        public double CostBasisPerShare { get; set; }
        public double CurrentValue { get; set; }
        public double CurrentPrice { get; set; }
        public string Term { get; set; }
        public double Profit { get; set; } //Loss will be negative
        public int Shares { get; set; }
    }
}
