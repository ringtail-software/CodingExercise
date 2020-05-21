namespace TradingApp.PerformanceApi.Tests.Controllers
{
    using Microsoft.Extensions.Logging;
    using Moq;
    using TradingApp.PerformanceApi.Controllers;
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
            // act
            var result = this.sut.Get();

            // assert
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

            // act
            var result = this.sut.Get(userId);

            // assert
            this.portfolio.Verify(m => m.GetInvestmentsByUserId(userId), Times.Once());
        }
    }
}
