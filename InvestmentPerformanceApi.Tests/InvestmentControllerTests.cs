using InvestmentPerformanceApi.Controllers;
using InvestmentPerformanceApi.Models;
using InvestmentPerformanceApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace InvestmentPerformanceApi.Tests
{
    public class InvestmentControllerTests
    {
        private InvestmentController _investmentController;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get_Investments_By_User_Should_Return_NotFound_For_An_Invalid_UserId()
        {
            // Mock the user not being found
            var mock = new Mock<IInvestmentRepository>();
            mock.Setup(repo => repo.GetInvestmentsByUser(0)).Returns(new List<Investment>());
            _investmentController = new InvestmentController(mock.Object);

            var result = _investmentController.GetInvestmentsByUser(0);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Get_Investments_By_User_Should_Return_Ok_For_A_Valid_UserId()
        {
            // Mock the user being found
            var investments = new List<Investment>();
            investments.Add(new Investment { Id = 1, Name = "Test1" });
            investments.Add(new Investment { Id = 2, Name = "Test2" });
            investments.Add(new Investment { Id = 3, Name = "Test3" });

            var mock = new Mock<IInvestmentRepository>();
            mock.Setup(repo => repo.GetInvestmentsByUser(1)).Returns(investments);
            _investmentController = new InvestmentController(mock.Object);

            var result = _investmentController.GetInvestmentsByUser(1);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Get_InvestmentDetails_Should_Return_NotFound_For_An_Invalid_InvestmentId()
        {
            // Mock the investment detail not being found
            InvestmentPerformance investmentPerformance = null;

            var mock = new Mock<IInvestmentRepository>();
            mock.Setup(repo => repo.GetInvestmentDetail(0)).Returns(investmentPerformance);
            _investmentController = new InvestmentController(mock.Object);

            var result = _investmentController.GetInvestmentDetail(0);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Get_InvestmentDetails_Should_Return_Ok_For_A_Valid_InvestmentId()
        {
            // Mock the investment being found
            InvestmentPerformance investmentPerformance = new InvestmentPerformance
            {
                Id = 1,
                Name = "Test1",
                Shares = 100,
                CostBasisPerShare = 0.1M,
                CurrentValue = 20,
                CurrentPrice = 0.2M,
                Term = Term.Long,
                NetGain = 10,
            };

            var mock = new Mock<IInvestmentRepository>();
            mock.Setup(repo => repo.GetInvestmentDetail(1)).Returns(investmentPerformance);
            _investmentController = new InvestmentController(mock.Object);

            var result = _investmentController.GetInvestmentDetail(1);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}