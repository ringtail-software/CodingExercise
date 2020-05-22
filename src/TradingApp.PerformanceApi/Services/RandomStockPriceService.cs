namespace TradingApp.PerformanceApi.Services
{
    using Bogus;

    /// <summary>
    /// An implementation of the <see cref="IStockPriceService"/> that returns randomized prices.
    /// </summary>
    public class RandomStockPriceService : IStockPriceService
    {
        /// <inheritdoc />
        public decimal GetCurrentPrice(string name)
        {
            return new Faker().Finance.Amount(1, 500, 2);
        }
    }
}
