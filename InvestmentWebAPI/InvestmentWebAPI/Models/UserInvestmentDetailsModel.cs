using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investment.API.Models
{
    public class UserInvestmentDetailsModel
    {
        public decimal Shares { get; set; }

        public decimal CostBasis { get; set; }

        public decimal CurrentValue { get; set; }

        public decimal CurrentPrice { get; set; }

        public string Term { get; set; }

        public decimal TotalGainLoss { get; set; }

    }
}
