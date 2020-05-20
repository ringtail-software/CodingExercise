using FluentAssertions;
using InvestmentPerformance.Api.Models;
using InvestmentPerformance.BLL.Models;
using InvestmentPerformance.BLL.Services;
using InvestmentPerformance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace InvestmentPerformance.Tests
{
    public class InvestmentServiceTest
    {
        private readonly InvestmentDbContext _db;
        private readonly InvestmentService _InvestmentService;
        private Stock _appleStock;
        private Stock _googleStock;
        private Stock _microsoftStock;
        private User _jordanBelfort;
        private User _warrenBuffet;
        private User _joelGramling;

        public InvestmentServiceTest()
        {
            _db = new InMemoryDb().Create();
            _InvestmentService = new InvestmentService(_db);
            InsertTestData();
        }

        private void InsertTestData()
        {
            //Users
            var jordanBelfortId = Guid.NewGuid();
            var warrenBuffetId = Guid.NewGuid();
            var joelGramlingId = Guid.NewGuid();
            _jordanBelfort = new User
            { Id = jordanBelfortId, UserName = "Jordan_Belfort" };
            _warrenBuffet = new User
                { Id = warrenBuffetId, UserName = "Warren_Buffet" };
            _joelGramling = new User
                { Id = joelGramlingId, UserName = "Joel_Gramling" };

            //Stocks
            var appleStockId = Guid.NewGuid();
            var googleStockId = Guid.NewGuid();
            var microsoftStockId = Guid.NewGuid();
            _appleStock = new Stock
                { Id = appleStockId, TickerSymbol = "AAPL", CurrentPrice = 420.69m };
            _googleStock = new Stock
                { Id = googleStockId, TickerSymbol = "GOOGL", CurrentPrice = 1010.49m };
            _microsoftStock = new Stock
                { Id = microsoftStockId, TickerSymbol = "MSFT", CurrentPrice = 200.20m };

            var users = new List<User> { _jordanBelfort, _warrenBuffet, _joelGramling };
            var stocks = new List<Stock> { _appleStock, _googleStock, _microsoftStock };

            _db.AddRange(users);
            _db.AddRange(stocks);
            _db.SaveChanges();
        }

        [Fact]
        public void GetCurrentInvestments_Returns_Multiple()
        {
            //ARRANGE
            var investment1 = new Investment
            { 
                Id = Guid.NewGuid(),
                User = _jordanBelfort,
                Stock = _appleStock,
                IsBuy = true, 
                Price = 313.14m,
                Shares = 200, 
                EventTime = DateTime.UtcNow.AddDays(-1) 
            };
            var investment2 = new Investment
            {
                Id = Guid.NewGuid(),
                User = _jordanBelfort,
                Stock = _microsoftStock,
                IsBuy = true,
                Price = 183.63m,
                Shares = 400,
                EventTime = DateTime.UtcNow
            };
            _db.AddRange(investment1, investment2);
            _db.SaveChanges();

            //ACT
            var investments = _InvestmentService.GetCurrentInvestments(_jordanBelfort.Id);

            //ASSERT
            investments.Should().NotBeEmpty();
            investments.Count().Should().BeGreaterThan(1);
        }

        [Fact]
        public void GetCurrentInvestments_Translates()
        {
            //ARRANGE
            var investment = new Investment
            {
                Id = Guid.NewGuid(),
                User = _jordanBelfort,
                Stock = _appleStock,
                IsBuy = true,
                Price = 313.14m,
                Shares = 200,
                EventTime = DateTime.UtcNow.AddDays(-1)
            };
            
            _db.Add(investment);
            _db.SaveChanges();

            //ACT
            var investments = _InvestmentService.GetCurrentInvestments(_jordanBelfort.Id);

            //ASSERT
            investments.Should().NotBeEmpty();
            investments.Count().Should().Be(1);
            investments.Single().Should().BeEquivalentTo(new UserInvestment { Id = investment.Id, Name = investment.Stock.TickerSymbol });
        }

        [Fact]
        public void GetCurrentInvestments_Returns_Null()
        {
            //ACT
            var investments = _InvestmentService.GetCurrentInvestments(_jordanBelfort.Id);

            //ASSERT
            investments.Should().BeEmpty();
            investments.Count().Should().Be(0);
        }

        [Fact]
        public void GetInvestment_Returns_Can_Translate()
        {
            //ARRANGE
            var investment1 = new Investment
            {
                Id = Guid.NewGuid(),
                User = _joelGramling,
                Stock = _appleStock,
                IsBuy = true,
                Price = 313.14m,
                Shares = 200,
                EventTime = DateTime.UtcNow.AddDays(-1)
            };
            var investment2 = new Investment
            {
                Id = Guid.NewGuid(),
                User = _joelGramling,
                Stock = _microsoftStock,
                IsBuy = true,
                Price = 183.63m,
                Shares = 400,
                EventTime = DateTime.UtcNow
            };
            _db.AddRange(investment1, investment2);
            _db.SaveChanges();

            //ACT
            var investment = _InvestmentService.GetInvestment(_joelGramling.Id, investment2.Id, DateTime.UtcNow.AddDays(1).AddYears(1));

            //ASSERT
            investment.Should().NotBeNull();
            investment.Should().BeEquivalentTo(
                new InvestmentDetails
                {
                    Shares = investment2.Shares,
                    CostBasis = 73452m,
                    CurrentPrice = _microsoftStock.CurrentPrice,
                    Term = "Long Term",
                });
            investment.TotalGainLoss.Should().BePositive();
            investment.TotalGainLoss.Should().Be(6628);
        }
    }
}
