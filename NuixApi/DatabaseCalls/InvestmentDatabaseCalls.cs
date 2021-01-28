using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuixApi.Models;

namespace NuixApi.DatabaseCalls
{
    public static class InvestmentDatabaseCalls
    {
   
        public static async Task<InvestmentOutput> GetInvestmentDetails(NuixContext _context ,int id)
        {   /*We get the record from both the investment and the investment details table by the id.
             We then do a linq statement to join the two tables based on the id*/
            return  (from investments in _context.Investments
                          join investmentDetails in _context.InvestmentDetails
                           on investments.Id equals investmentDetails.Id
                          where investments.Id == id
                          select (new InvestmentOutput()
                          {
                              Id = investments.Id,
                              Name = investments.InvestmentName,
                              NumberOfShares = investmentDetails.NumberOfSharesOwned,
                              CostBasisPerShare = investmentDetails.PriceWhenPurchased,
                              CurrentPrice = investmentDetails.CurrentPrice,
                              Term = investmentDetails.DatePurchased.AddDays(366) > DateTime.Today ? "Short Term" : "Long Term", //If less than 1 year then it is short term otherwise it is long term
                              CurrentValue = investmentDetails.CurrentPrice * investmentDetails.NumberOfSharesOwned,
                              GainOrLoss = (investmentDetails.CurrentPrice * investmentDetails.NumberOfSharesOwned) - (investmentDetails.PriceWhenPurchased * investmentDetails.NumberOfSharesOwned)
                          })).FirstOrDefault();
        }
    }
}
