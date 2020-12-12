using InvestmentPerformance.Data.Context;
using InvestmentPerformance.Data.Entities;
using InvestmentPerformance.WebAPI.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentPerformance.WebAPI.Tests
{
    public class FakeInvestmentPerformanceRepository : IInvestmentPerformanceRepository
    {
        InvestmentPerformanceContext _context;

        public FakeInvestmentPerformanceRepository()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<InvestmentPerformanceContext>().UseSqlite(connection).Options;
            var context = new InvestmentPerformanceContext(options);
            context.Database.EnsureCreated();

            // create some mock data to test with. 
            context.Users.AddRange(
                new User
                {
                    UserId = 1,
                    FirstName = "George",
                    LastName = "Washington"
                },
                new User
                {
                    UserId = 2,
                    FirstName = "Abraham",
                    LastName = "Lincoln"
                }
            );

            context.Stocks.AddRange(
                new Stock
                {
                    TickerSymbol = "MSFT",
                    CompanyName = "Microsoft Corporation",
                    CurrentPrice = 213.26M,
                    Open = 210.05M,
                    PreviousClose = 210.52M,
                    Bid = 213.05M,
                    Ask = 212.96M,
                    Volume = 28485071
                },
                new Stock
                {
                    TickerSymbol = "AMZN",
                    CompanyName = "Amazon.com, Inc.",
                    CurrentPrice = 3116.42M,
                    Open = 3096.66M,
                    PreviousClose = 3101.49M,
                    Bid = 3108.54M,
                    Ask = 3112.62M,
                    Volume = 2940618
                },
                new Stock
                {
                    TickerSymbol = "PFE",
                    CompanyName = "Pfizer Inc.",
                    CurrentPrice = 41.12M,
                    Open = 41.97M,
                    PreviousClose = 41.73M,
                    Bid = 41.27M,
                    Ask = 41.29M,
                    Volume = 58902778
                }
            );

            context.UserInvestments.AddRange(
                new UserInvestment
                {
                    InvestmentId = 1,
                    UserId = 1,
                    TickerSymbol = "MSFT",
                    ShareCount = 100M,
                    CostBasis = 208.11M,
                    PurchaseDate = new DateTime(2020, 4, 10)
                },
                new UserInvestment
                {
                    InvestmentId = 2,
                    UserId = 1,
                    TickerSymbol = "AMZN",
                    ShareCount = 50M,
                    CostBasis = 2954.21M,
                    PurchaseDate = new DateTime(2020, 2, 1)
                },
                new UserInvestment
                {
                    InvestmentId = 3,
                    UserId = 2,
                    TickerSymbol = "MSFT",
                    ShareCount = 25M,
                    CostBasis = 219.11M,
                    PurchaseDate = new DateTime(2020, 8, 17)
                },
                new UserInvestment
                {
                    InvestmentId = 4,
                    UserId = 2,
                    TickerSymbol = "PFE",
                    ShareCount = 1000M,
                    CostBasis = 31.87M,
                    PurchaseDate = new DateTime(2017, 6, 1)
                }
            );

            context.SaveChanges();
            _context = context;
        }

        public List<UserInvestment> GetAllInvestmentsForUser(int userId)
        {
            var userInvestments = _context.UserInvestments.Include(x => x.Stock).Where(x => x.UserId == userId).ToList();
            return userInvestments;          
        }

        public UserInvestment GetInvestmentDetailsById(int userId, int investmentId)
        {
            var userInvestments = _context.UserInvestments
                .Include(x => x.Stock)
                .Where(x => x.UserId == userId && x.InvestmentId == investmentId).FirstOrDefault();

            return userInvestments;          
        }
    }
}
