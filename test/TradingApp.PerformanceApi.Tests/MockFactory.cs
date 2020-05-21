namespace TradingApp.PerformanceApi.Tests
{
    using Microsoft.Extensions.Logging;
    using Moq;

    /// <summary>
    /// Create mocked instances for test cases.
    /// </summary>
    public static class MockFactory
    {
        /// <summary>
        /// Create a logger for the given type.
        /// </summary>
        /// <typeparam name="T">The class type for the logger context.</typeparam>
        /// <returns>The logger instance.</returns>
        public static ILogger<T> CreateLogger<T>() => new Mock<ILogger<T>>().Object;
    }
}
