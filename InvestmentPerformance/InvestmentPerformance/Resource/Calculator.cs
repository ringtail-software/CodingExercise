using InvestmentPerformance.Models;
using System;

namespace InvestmentPerformance.Resource
{
    public static class Calculator
    {
        public static TermType CalculateTerm(DateTime purchasedTimeStamp)
        {
            var yearDiff = DateTime.Now.Year - purchasedTimeStamp.Year;
            return yearDiff <= 1 ? TermType.ShortTerm : TermType.LongTerm;
        }

        public static double CalculateProfit(double purchasedPrice, int shares, double currentPrice)
        {
            return Math.Round((currentPrice - purchasedPrice) * shares,2);
        }

        public static double CalculateCurrentValue(int shares, double currentPrice)
        {
            return Math.Round(shares * currentPrice,2);
        }
    }
}
