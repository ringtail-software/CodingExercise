namespace TradingApp.PerformanceApi.Tests.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using TradingApp.PerformanceApi.Controllers;
    using TradingApp.PerformanceApi.Models;
    using TradingApp.PerformanceApi.Services;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="InvestmentsController"/> class.
    /// </summary>
    public class InvestmentsControllerTests
    {
        private readonly InvestmentsController sut;

        private readonly Mock<ILogger<InvestmentsController>> logger;
        private readonly Mock<IPortfolioService> portfolio;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentsControllerTests"/> class.
        /// </summary>
        public InvestmentsControllerTests()
        {
            this.logger = new Mock<ILogger<InvestmentsController>>();
            this.portfolio = new Mock<IPortfolioService>();

            this.sut = new InvestmentsController(this.logger.Object, this.portfolio.Object);
        }

        /// <summary>
        /// It should get a list of investments.
        /// </summary>
        [Fact]
        public void ShouldGetInvestments()
        {
            // arrange
            var expected = new List<InvestmentSummary>
            {
                new InvestmentSummary { Id = 1, UserId = 1, Name = "Foo" },
                new InvestmentSummary { Id = 2, UserId = 1, Name = "Bar" },
                new InvestmentSummary { Id = 3, UserId = 2, Name = "Baz" },
            };

            this.portfolio.Setup(m => m.GetInvestments()).Returns(expected);

            // act
            var result = this.sut.Get();

            // assert
            Assert.Equal(expected, result);
            this.portfolio.Verify(m => m.GetInvestments(), Times.Once());
        }

        /// <summary>
        /// It should get a list of investments for a specific user.
        /// </summary>
        [Fact]
        public void ShouldGetInvestmentsByUserId()
        {
            // arrange
            var userId = 999;

            var expected = new List<InvestmentSummary>
            {
                new InvestmentSummary { Id = 1, UserId = 1, Name = "Foo" },
                new InvestmentSummary { Id = 2, UserId = 1, Name = "Bar" },
            };

            this.portfolio.Setup(m => m.GetInvestmentsByUserId(userId)).Returns(expected);

            // act
            var result = this.sut.Get(userId);

            // assert
            Assert.Equal(expected, result);
            this.portfolio.Verify(m => m.GetInvestmentsByUserId(userId), Times.Once());
        }

        /// <summary>
        /// It should get investment details by id.
        /// </summary>
        [Fact]
        public void ShouldGetIvestmentDetails()
        {
            // arrange
            var id = 7;

            var expected = new InvestmentDetails
            {
                Id = 1,
                UserId = 2,
                Name = "Foo",
                Shares = 12,
                CostBasisPerShare = 29.00m,
                CurrentPricePerShare = 75.84m,
            };

            this.portfolio.Setup(m => m.GetInvestmentDetails(id)).Returns(expected);

            // act
            var response = this.sut.Details(id);

            // assert
            Assert.Equal(expected, response.Value);
            this.portfolio.Verify(m => m.GetInvestmentDetails(id), Times.Once());
        }

        /// <summary>
        /// It should return a 404 (not found) response if no investment is found.
        /// </summary>
        [Fact]
        public void ShouldThrow404IfDetailsNotFound()
        {
            // arrange
            this.portfolio.Setup(m => m.GetInvestmentDetails(It.IsAny<int>())).Returns(() => null);

            // act
            var response = this.sut.Details(1);

            // assert
            Assert.IsType<NotFoundResult>(response.Result);
            this.portfolio.Verify(m => m.GetInvestmentDetails(It.IsAny<int>()), Times.Once());
        }
    }
}
