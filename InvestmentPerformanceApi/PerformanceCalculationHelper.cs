using InvestmentPerformanceApi.Models;
using System;

namespace InvestmentPerformanceApi
{
    public static class PerformanceCalculationHelper
    {
        /// <summary>
        /// Determines if the term is long term (> 1 year) or short term (<= 1 year)
        /// </summary>
        /// <param name="purchaseDate">The date the shares of stock were purchased</param>
        /// <returns>long term if the shares have been owned more than 1 year, otherwise short term</returns>
        public static Term GetTerm(DateTime purchaseDate)
        {
            return GetTerm(purchaseDate, DateTime.Now);
        }

        /// <summary>
        /// Determines if the term is long term (> 1 year) or short term (<= 1 year)
        /// </summary>
        /// <param name="purchaseDate">The date the shares of stock were purchased</param>
        /// <returns>long term if the shares have been owned more than 1 year, otherwise short term</returns>
        public static Term GetTerm(DateTime purchaseDate, DateTime endDate)
        {
            // Add one day to the difference of days between the dates, so that the end date is included as a day
            var totalDays = (endDate - purchaseDate).TotalDays + 1;
            return totalDays > 365 ? Term.Long : Term.Short;
        }

        /// <summary>
        /// Calculates the net gain or loss of a stock purchase
        /// </summary>
        /// <param name="shares">Number of shares</param>
        /// <param name="currentPrice">Current stock price</param>
        /// <param name="purchaseCostPerShare">Stock price at purchase</param>
        /// <returns>Returns net gain or a negative if the net gain is a loss</returns>
        public static decimal CalculateNetGain(int shares, decimal currentPrice, decimal purchaseCostPerShare)
        {
            return (shares * currentPrice) - (shares * purchaseCostPerShare);
        }
    }
}
