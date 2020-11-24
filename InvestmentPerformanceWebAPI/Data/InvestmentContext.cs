using InvestmentPerformanceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvestmentPerformanceWebAPI.Data
{
    public class InvestmentContext : DbContext, IInvestmentContext
    {
        public IDbSet<Investment> Investments { get; set; }
        public IDbSet<InvestmentDetail> InvestmentDetails { get; set; }
    }
}