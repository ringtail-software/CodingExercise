using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentPerformanceWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformanceWebApi.Domain
{
    public class InvestmentDataContext : DbContext
    {
        public InvestmentDataContext(DbContextOptions<InvestmentDataContext> options) : base(options)
        {

        }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public void Initialize()
        {
            if (!Database.EnsureCreated())
                return;


            var stocks = new Stock[]
            {
                new Stock {Symbol = "MSFT", Name = "Microsoft", Price = 252.18m},
                new Stock {Symbol = "GOOGL", Name = "Alphabet Class A", Price = 2352.50m},
                new Stock {Symbol = "AAPL", Name = "Apple", Price = 131.46m},
                new Stock {Symbol = "AMZN", Name = "Amazon", Price = 3467.00m},
                new Stock {Symbol = "ORCL", Name = "Oracle", Price = 75.79m},
            };

            DateTime seedTime = new DateTime(2021, 05, 02);
            double maxTimeOffset = -TimeSpan.FromDays(365 * 2).TotalSeconds;

            Random rand = new Random(93874289); // Random but always the same result
            var investments = Enumerable.Range(0, 100)
                .Select(i => new {UserId = i % 3 + 1, Stock = stocks[rand.Next(stocks.Length)]})
                .Select(i => new Investment
                {
                    UserId = i.UserId,
                    Quantity = rand.Next(1, 100),
                    Symbol = i.Stock.Symbol,
                    InvestmentName = i.Stock.Name,
                    PurchaseTimestamp = seedTime.AddSeconds(rand.NextDouble() * maxTimeOffset),
                    CostBasis = Math.Round(i.Stock.Price * (decimal)(rand.NextDouble() * 0.2 + 0.9), 2),
                })
                .OrderBy(i => i.PurchaseTimestamp)
                .ToArray();

            Investments.AddRange(investments);
            SaveChanges();

            Stocks.AddRange(stocks);
            SaveChanges();
        }
    }
}
