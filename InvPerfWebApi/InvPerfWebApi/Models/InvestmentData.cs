using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvPerfWebApi.Models
{
    public class InvestmentData
    {
        public string userName { get; set; }
        public int invId { get; set; }
        public string invName { get; set; }
        public int numShares { get; set; }
        public int costBasisPerShare { get; set; }
        public double currentValue { get; set; }
        public double currentPrice { get; set; }
        public string term { get; set; }
        public double totalGainLoss { get; set; }
    }

    public class UserInvestment
    {
        public string userName { get; set; }
        public int invId { get; set; }
        public string invName { get; set; }
    }

    public class UserInvestmentDetail {
    public string userName { get; set; }
    public string invName { get; set; }
    public int numShares { get; set; }
    public int costBasisPerShare { get; set; }
    public double currentValue { get; set; }
    public double currentPrice { get; set; }
    public string term { get; set; }
    public double totalGainLoss { get; set; }
}
    }