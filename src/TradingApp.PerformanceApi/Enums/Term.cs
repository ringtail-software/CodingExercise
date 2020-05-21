namespace TradingApp.PerformanceApi.Enums
{
    /// <summary>
    /// Represents how long the stock has been owned.
    /// </summary>
    public enum Term
    {
        /// <summary>
        /// Short term is less than or equal to one year.
        /// </summary>
        Short,

        /// <summary>
        /// Long term is greater than one year.
        /// </summary>
        Long,
    }
}
