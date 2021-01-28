using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuixApi.Models
{
    public class InvestmentOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfShares { get; set; }
        public double CostBasisPerShare { get; set; }
        public double CurrentValue { get; set; }
        public double CurrentPrice { get; set; }
        public string Term { get; set; }

        public double GainOrLoss { get; set; }
    }
}
