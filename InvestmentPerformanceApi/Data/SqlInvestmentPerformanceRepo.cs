using InvestmentPerformanceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentPerformanceApi.Data
{
    public class SqlInvestmentPerformanceRepo : IInvestmentPerformanceRepo
    {
        private readonly InvestmentPerformanceContext _context;

        public SqlInvestmentPerformanceRepo(InvestmentPerformanceContext context)
        {
            _context = context;
        }

        public IEnumerable<Investments> Get(int userId)
        {
            yield return _context.Investments.FirstOrDefault(u => u.UserId == userId);
        }
        public IEnumerable<InvestmentDetails> GetDetails(int userId, int investmentId)
        {
            yield return _context.InvestmentDetails.FirstOrDefault(i => i.UserId == userId && i.InvestmentId == investmentId);
        }

        public void Buy(InvestmentDetails buy)
        {
            if (buy == null)
            {
                throw new ArgumentNullException(nameof(buy));
            }
            _context.InvestmentDetails.Add(buy);
        }

        public void Sell(IEnumerable<InvestmentDetails> sell)
        {
            if (sell == null)
            {
                throw new ArgumentNullException(nameof(sell));
            }
            _context.InvestmentDetails.Remove((InvestmentDetails)sell);
        }

        public void Update(IEnumerable<InvestmentDetails> investModel)
        {

        }

        //public bool SaveChanges()
        //{
        //    return (_context.SaveChanges() >= 0);
        //}
    }
}
