using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ZachAlbertCodingExercise;
using ZachAlbertCodingExercise.Domain;
using NUnit.Framework;
using NSubstitute;
using ZachAlbertCodingExercise.Models;

namespace ZachAlbertCodingExercise.Tests
{
    [TestFixture]
    public class InvestmentControllerTests
    {
        private InvestmentController _controller;
        private InvestmentManager _manager;

        [SetUp]
        public void SetUp()
        {
            _manager = Substitute.For<InvestmentManager>(null as InvestmentDal);
            _controller = new InvestmentController(_manager)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [Test]
        public async Task GetUserInvestment()
        {
            var methodReturn = new List<UserInvestment>{new UserInvestment{InvestmentId = 1, StockId = 1, StockName = "Nuix"}};

            _manager.GetUserInvestments(Arg.Any<int>()).Returns(methodReturn);

            var result = await _controller.RetrieveUserInvestments(Arg.Any<int>());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].InvestmentId, 1);
        }

        [Test]
        public async Task GetUserInvestmentDetail()
        {
            var methodReturn = new List<UserInvestment>
            {
                new UserInvestment
                {
                    InvestmentId = 1,
                    StockId = 1,
                    StockName = "Nuix",
                    CurrentStockPrice = 10,
                    PurchaseAmount = 10,
                    PurchasePrice = 5,
                    PurchaseDate = new DateTime(2019, 12, 12)
                }
            };

            _manager.GetUserInvestments(Arg.Any<int>(),Arg.Any<int>()).Returns(methodReturn);

            var result = await _controller.RetrieveUserInvestmentDetails(Arg.Any<int>(), Arg.Any<int>());
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].InvestmentId, 1);
        }
    }
}
