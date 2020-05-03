using System;

namespace InvestmentAPI.Utility
{
    public static class InvestmentCalculator
    {
        /// <summary>
        /// Will generate a new price for the stock based on CostBasisPerShare.
        /// </summary>
        /// <param name="costBasisPerShare">The initial price per share of the stock at purchase</param>
        /// <returns>Random price</returns>
        public static double GeneratePrice(double costBasisPerShare)
        {
            Random rand = new Random();
            int number;
            number = rand.Next(-100, 100);

            var result = costBasisPerShare += number;
            return Math.Round(result, 2);
        }

        /// <summary>
        /// Determines investment value based on number of shares and current price.
        /// </summary>
        /// <param name="shares">Number of shares</param>
        /// <param name="price">Current price</param>
        /// <returns>Value of investment</returns>
        public static double DetermineValue(int shares, double price)
        {
            return Math.Round(shares * price);
        }

        /// <summary>
        /// Will determine the net loss/gain of an investment based on value, # of shares, and cost basis.
        /// </summary>
        /// <param name="value">Current share value</param>
        /// <param name="shares">Number of shares purchases</param>
        /// <param name="costBasisPerShare">Cost of share at time of purchase</param>
        /// <returns>Net gain/loss</returns>
        public static double DetermineNetValuation(double value, int shares, double costBasisPerShare)
        {
            return Math.Round(value - (shares * costBasisPerShare));
        }
    }
}
