using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentPerformanceWebAPI.Helpers
{
    public static class InvestmentHelper
    {
        /// <summary>
        /// Gets the current value based on the given amount of shares and current price
        /// </summary>
        /// <returns>the current value</returns>
        public static double GetCurrentValue(int shares, double currentPrice)
        {
            return shares * currentPrice;
        }

        /// <summary>
        /// Gets the term based on the given purchaseDate
        /// </summary>
        /// <returns>0 short term, 1 long term</returns>
        public static byte GetTerm(DateTime purchaseDate)
        {
            // determine if the term is short-term or long term
            if (purchaseDate.CompareTo(DateTime.UtcNow.AddYears(-1)) < 0)
            {
                return 1; // long term
            }
            else
            {
                return 0; // short term
            }
        }
        /// <summary>
        /// Gets the Net Gain or Loss based on the current value, # of shares, and original cost per share
        /// </summary>
        /// <returns>the Net Gain or Loss</returns>
        public static double GetNetGainLoss(double currentValue, int shares, double costBasisPerShare)
        {
            return Math.Round(currentValue - (shares * costBasisPerShare));
        }
    }
}