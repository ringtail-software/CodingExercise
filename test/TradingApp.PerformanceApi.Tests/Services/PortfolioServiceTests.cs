namespace TradingApp.PerformanceApi.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using TradingApp.Data.Entities;
    using TradingApp.Data.Repositories;
    using TradingApp.PerformanceApi.Models;
    using TradingApp.PerformanceApi.Services;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="PortfolioService"/> class.
    /// </summary>
    public class PortfolioServiceTests
    {
        private readonly Mock<IRepository<Investment>> repo;
        private readonly Mock<IStockPriceService> pricing;

        private IPortfolioService sut;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioServiceTests"/> class.
        /// </summary>
        public PortfolioServiceTests()
        {
            this.repo = new Mock<IRepository<Investment>>();
            this.pricing = new Mock<IStockPriceService>();

            this.sut = new PortfolioService(this.repo.Object, this.pricing.Object);
        }

        /// <summary>
        /// It should return details for an investment.
        /// </summary>
        [Fact]
        public void ShouldGetInvestmentDetails()
        {
            // arrange
            var purchaseDate = DateTime.Now.AddDays(-25);

            this.repo.Setup(m => m.FindById(It.IsAny<int>()))
                .Returns(new Investment
                {
                    Id = 1,
                    UserId = 2,
                    Name = "Foo",
                    PurchaseDate = purchaseDate,
                    PurchasePrice = 25.00m,
                    Shares = 100,
                });

            this.pricing.Setup(m => m.GetCurrentPrice(It.IsAny<string>()))
                .Returns(50.00m);

            // act
            var details = this.sut.GetInvestmentDetails(1);

            // assert
            Assert.Equal(1, details.Id);
            Assert.Equal(2, details.UserId);
            Assert.Equal("Foo", details.Name);
            Assert.Equal(100, details.Shares);
            Assert.Equal(25.00m, details.CostBasisPerShare);
            Assert.Equal(50.00m, details.CurrentPricePerShare);
            Assert.Equal(purchaseDate, details.PurchaseDate);
            Assert.Equal(Enums.Term.Short, details.Term);
            Assert.Equal(5000.00m, details.CurrentValue);
            Assert.Equal(2500.00m, details.TotalGain);
        }

        /// <summary>
        /// It should get all investment summaries.
        /// </summary>
        [Fact]
        public void ShouldGetInvestments()
        {
            // arrange
            this.repo.Setup(m => m.GetAll())
                .Returns(new List<Investment>
                {
                    new Investment { Id = 1, UserId = 1, Name = "Foo" },
                    new Investment { Id = 2, UserId = 1, Name = "Bar" },
                    new Investment { Id = 3, UserId = 2, Name = "Baz" },
                }.AsQueryable());

            var expected = new List<InvestmentSummary>
            {
                new InvestmentSummary { Id = 1, UserId = 1, Name = "Foo" },
                new InvestmentSummary { Id = 2, UserId = 1, Name = "Bar" },
                new InvestmentSummary { Id = 3, UserId = 2, Name = "Baz" },
            };

            // act
            var results = this.sut.GetInvestments().ToList();

            // assert
            Assert.Equal(3, results.Count);
            this.repo.Verify(m => m.GetAll(), Times.Once());
        }

        /// <summary>
        /// It should return investment summaries for a specific user.
        /// </summary>
        [Fact]
        public void ShouldGetINvestmentsByUserId()
        {
            // arrange
            var userId = 1;

            this.repo.Setup(m => m.GetAll())
                .Returns(new List<Investment>
                {
                    new Investment { Id = 1, UserId = 1, Name = "Foo" },
                    new Investment { Id = 2, UserId = 1, Name = "Bar" },
                }.AsQueryable());

            var expected = new List<InvestmentSummary>
            {
                new InvestmentSummary { Id = 1, UserId = 1, Name = "Foo" },
                new InvestmentSummary { Id = 2, UserId = 1, Name = "Bar" },
            };

            // act
            var results = this.sut.GetInvestmentsByUserId(userId).ToList();

            // assert
            Assert.Equal(2, results.Count);
            this.repo.Verify(m => m.GetAll(), Times.Once());
        }
    }
}
