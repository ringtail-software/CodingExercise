using InvestmentPerformance.Api.Models;
using InvestmentPerformance.BLL.Models;
using InvestmentPerformance.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentPerformance.BLL.Services
{
    public interface IInvestmentService
    {
        IEnumerable<UserInvestment> GetCurrentInvestments(Guid userId);
        InvestmentDetails GetInvestment(Guid userId, Guid investmentId, DateTime utcNow);
    }
    public class InvestmentService : IInvestmentService
    {
        private readonly InvestmentDbContext _db;
        public InvestmentService(InvestmentDbContext db)
        {
            _db = db;
        }
        public IEnumerable<UserInvestment> GetCurrentInvestments(Guid userId)
        {
            var userInvestments = _db.Investments
                .Where(i => i.UserId == userId)
                .Select(i => new UserInvestment{ 
                    Id = i.Id,
                    Name = i.Stock.TickerSymbol 
                })
                .ToList();
            return userInvestments;
        }

        public InvestmentDetails GetInvestment(Guid userId, Guid investmentId, DateTime utcNow)
        {
            var userInvestments = _db.Investments.Include(x => x.Stock)
                .Where(i => i.Id == investmentId && i.UserId == userId && i.IsBuy == true)
                .Select(i => new InvestmentDetails
                {
                    Shares = i.Shares,
                    CostBasis = (decimal)i.Shares * i.Price,
                    CurrentPrice = i.Stock.CurrentPrice,
                    Term = (utcNow - i.EventTime).Days < 365 ? "Short Term" : "Long Term",
                })
                .SingleOrDefault();
            return userInvestments;
        }
    }
}
