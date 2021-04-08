using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RingTail;
using RingTail.Controllers;

namespace UnitTests {
    public class WebApiTest {
        private Investments _investmentController;
        private List<Stock> _stocks;

        [SetUp]
        public void Setup() {
            _stocks = new List<Stock> {
                new Stock {
                    Id = "1",
                    Name = "AAPL",
                    NameReadable = "Apple",
                    CostBasis = 0.25m,
                    Price = 4.00m,
                    Shares = 10,
                    AcquiredDate = new DateTime(2001, 10, 16),
                },
                new Stock {
                    Id = "2",
                    Name = "Google",
                    NameReadable = "GOOGL",
                    CostBasis = 849.08m,
                    Price = 2225.29m,
                    Shares = 6,
                    AcquiredDate = new DateTime(2001, 10, 16),
                },
                new Stock {
                    Id = "1",
                    Name = "AAPL",
                    NameReadable = "Apple",
                    CostBasis = 0.25m,
                    Price = 4.00m,
                    Shares = 10,
                    AcquiredDate = new DateTime(2001, 10, 16),
                }
            };
            _investmentController = new Investments(true, _stocks);
        }

        [Test]
        public void GetUserStocksTest() {
            Assert.Throws<Exception>(delegate { _investmentController.UserStocks(""); });
            Assert.DoesNotThrow(delegate { _investmentController.UserStocks("1"); });
            Assert.DoesNotThrow(delegate { _investmentController.UserStocks("2"); });

            var response = _investmentController.UserStocks("1");

            var enumerable = response.ToList();
            if (enumerable.Count() != 3) {
                Assert.Fail();
            }

            if (enumerable.Distinct().Count() != 3) {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void GetUserStockDetailsTest() {
            Assert.Throws<Exception>(delegate { _investmentController.UserStocksByStock("", ""); });
            Assert.Throws<Exception>(delegate { _investmentController.UserStocksByStock("1", ""); });
            Assert.Throws<Exception>(delegate { _investmentController.UserStocksByStock("", "1"); });
            Assert.DoesNotThrow(delegate { _investmentController.UserStocksByStock("1", "1"); });
            Assert.DoesNotThrow(delegate { _investmentController.UserStocksByStock("2", "1"); });
            Assert.DoesNotThrow(delegate { _investmentController.UserStocksByStock("1", "4"); });

            var response = _investmentController.UserStocksByStock("1", "1");

            if (!response.Id.Equals("1")) {
                Assert.Fail();
            }

            if (!response.Name.Equals("AAPL")) {
                Assert.Fail();
            }
            
            if (response.InitialValue != 2.50m) {
                Assert.Fail();
            }

            Assert.Pass();
        }
    }
}