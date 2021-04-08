using System;
using System.Linq;
using NUnit.Framework;
using RingTail;
using RingTail.Controllers;

namespace UnitTests {
    public class Tests {
        private Stock _stock;

        [SetUp]
        public void Setup() {
            _stock = new Stock {
                Id = "1",
                Name = "AAPL",
                NameReadable = "Apple",
                CostBasis = 0.25m,
                Price = 4.00m,
                Shares = 10,
                AcquiredDate = new DateTime(2001, 10, 16),
            };
        }

        [Test]
        public void StockModelValue() {
            if (_stock.InvestmentType != InvestmentType.Stock) {
                Assert.Fail();
            }
            if (_stock.CurrentValue != 40.00m) {
                Assert.Fail();
            }
            if (_stock.InitialValue != 2.50m) {
                Assert.Fail();
            }
            if (_stock.TotalDelta != 37.50m) {
                Assert.Fail();
            }

            Assert.Pass();
        }
        
        [Test]
        public void StockTermCheck() {
            if (_stock.Term == InvestmentTerm.ShortTerm) {
                Assert.Fail();
            }
            _stock.AcquiredDate = DateTime.Now.AddYears(-1);
            if (_stock.Term == InvestmentTerm.ShortTerm) {
                Assert.Fail();
            }

            _stock.AcquiredDate = _stock.AcquiredDate.AddDays(1);
            if (_stock.Term == InvestmentTerm.LongTerm) {
                Assert.Fail();
            }
            
            _stock.AcquiredDate = _stock.AcquiredDate.AddDays(-2);
            if (_stock.Term == InvestmentTerm.ShortTerm) {
                Assert.Fail();
            }
            
            Assert.Pass();
        }
    }
}