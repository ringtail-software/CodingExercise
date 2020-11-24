using InvestmentPerformanceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace InvestmentPerformanceWebAPI.Data
{
    public interface IInvestmentContext
    {
        IDbSet<Investment> Investments { get; }
        IDbSet<InvestmentDetail> InvestmentDetails { get; }
        int SaveChanges();
    }
}