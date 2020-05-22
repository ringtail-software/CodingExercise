namespace TradingApp.PerformanceApi.Services
{
    /// <summary>
    /// Interface for a service to provide stock pricing.
    /// </summary>
    public interface IStockPriceService
    {
        /// <summary>
        /// Get the current price for a stock.
        /// </summary>
        /// <param name="name">The stock name.</param>
        /// <returns>The current price.</returns>
        decimal GetCurrentPrice(string name);
    }
}
