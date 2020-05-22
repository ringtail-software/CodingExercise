namespace TradingApp.PerformanceApi.Tests.Models
{
    using System;
    using TradingApp.PerformanceApi.Enums;
    using TradingApp.PerformanceApi.Models;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="InvestmentDetails"/> class.
    /// </summary>
    public class InvestmentDetailsTests
    {
        private readonly InvestmentDetails sut;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentDetailsTests"/> class.
        /// </summary>
        public InvestmentDetailsTests()
        {
            this.sut = new InvestmentDetails();
        }

        /// <summary>
        /// It should determine and assign the term classification based on original purchase date.
        /// </summary>
        /// <param name="days">Number of days since original purchase.</param>
        /// <param name="expected">The expected term assignment.</param>
        [Theory]
        [InlineData(1000, Term.Long)]
        [InlineData(363, Term.Short)]
        [InlineData(366, Term.Long)]
        [InlineData(50, Term.Short)]
        public void ShouldDetermineTerm(int days, Term expected)
        {
            this.sut.PurchaseDate = DateTime.Now.AddDays(days * -1);
            Assert.Equal(expected, this.sut.Term);
        }

        /// <summary>
        /// It should calculate the current value based on shares and current price.
        /// </summary>
        /// <param name="shares">The number of shares owned.</param>
        /// <param name="currentPrice">The current price per share.</param>
        [Theory]
        [InlineData(1, 1.00)]
        [InlineData(3, 27.95)]
        [InlineData(999, -1.00)]
        [InlineData(999999, 0)]
        public void ShouldCalculateCurrentValue(int shares, decimal currentPrice)
        {
            var expected = shares * currentPrice;

            this.sut.CurrentPricePerShare = currentPrice;
            this.sut.Shares = shares;

            Assert.Equal(expected, this.sut.CurrentValue);
        }

        /// <summary>
        /// It should calculate the total gains or loss.
        /// </summary>
        /// <param name="shares">The number of shares.</param>
        /// <param name="costBasis">The original purchase price per share.</param>
        /// <param name="currentPrice">The current price per share.</param>
        [Theory]
        [InlineData(1, 1.00, 1.00)]
        [InlineData(9, 27.95, 48.99)]
        [InlineData(50, 50.91, 18.52)]
        public void ShouldCalculateTotalGain(int shares, decimal costBasis, decimal currentPrice)
        {
            var expected = (shares * currentPrice) - (shares * costBasis);

            this.sut.Shares = shares;
            this.sut.CostBasisPerShare = costBasis;
            this.sut.CurrentPricePerShare = currentPrice;

            Assert.Equal(expected, this.sut.TotalGain);
        }
    }
}
