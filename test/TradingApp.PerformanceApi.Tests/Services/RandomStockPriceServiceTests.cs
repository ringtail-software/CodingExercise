namespace TradingApp.PerformanceApi.Tests.Services
{
    using TradingApp.PerformanceApi.Services;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Unit tests for the <see cref="RandomStockPriceService"/> class.
    /// </summary>
    public class RandomStockPriceServiceTests
    {
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomStockPriceServiceTests"/> class.
        /// </summary>
        /// <param name="output">Test logger.</param>
        public RandomStockPriceServiceTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// It should return a randomized current price.
        /// </summary>
        [Fact]
        public void ShouldReturnRandomizedPrice()
        {
            // arrange
            var sut = new RandomStockPriceService();

            // act
            var price = sut.GetCurrentPrice("FOO");
            this.output.WriteLine($"Randomized price: {price}");

            // assert
            Assert.True(price >= 0);
        }
    }
}
