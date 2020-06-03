using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentPerformance.Services
{
    /// <summary>
    ///this service will ideally call a stock ticker api to get the realtime currentprice.
    ///but since we are doing a coding exercise, this will randomly add/subtract an amount from the stock price.
    /// </summary>
    public class CurrentPriceService : ICurrentPriceService
    {
        public double GetCurrentPrice(double price)
        {
            double randomPriceMovement = GetRandomNumber(-price, price);
            return price + randomPriceMovement;
        }

        /// <summary>
        /// generate a random double which can be negative
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        private static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

    }
}
