using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class API
    {
        private InvestmentDatabase myDB;
        public API(InvestmentDatabase oDB) {
            myDB = oDB;
        }

        public API()
        {
            myDB = new InvestmentDatabase();}
        /// <summary>
        /// Connect to the database and retrieve the investments
        /// </summary>
        /// <param name="investorID"></param>
        /// <returns>list of investments</returns>
        public List<Stock> GetInvestments(int investorID)
        {
            List<Stock> ret = null;
            try
            {
                
                ret = myDB.GetInvestments(investorID);

            }catch(Exception ex)
            { throw ex; }

            return ret;
        }

        /// <summary>
        /// Connect to the database and retrieve the Investment detail data
        /// </summary>
        /// <param name="investorID"></param>
        /// <param name="investmentID"></param>
        /// <returns>Investment detail</returns>
        public Investment GetInvestmentDetails(int investorID, int investmentID)
        {
            Investment ret = null;
            try
            {
                ret = myDB.GetInvestmentByID(investorID, investmentID);
                if (ret != null)
                {
                    ret.CurrentValue = CalculateCurrentValue(ret.NumShares, ret.CurrentPrice);
                    ret.Term = GetTerm(ret.PurchasedOn);
                    ret.TotalLostGains = CalculateTotalLostGains(ret.NumShares, ret.CurrentPrice, ret.BasicCostPerShare);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return ret;
        }

        /// <summary>
        /// function to calculate the total gain or loss:
        /// the difference between the current value, and the amount paid for all shares when they were purchased
        /// </summary>
        /// <param name="numShares">number of shares</param>
        /// <param name="currentPrice">the current price per share</param>
        /// <param name="basicPrice">the amount paid for 1 share when they were purchased</param>
        /// <returns>Total lost or Gains</returns>
        public double CalculateTotalLostGains(int numShares, double currentPrice, double basicPrice)
        {
            return numShares * (currentPrice - basicPrice);
        }

        /// <summary>
        /// calculate how long the stock has been owned since the purchased date
        /// if purchased less than one year is short term, greater than 1 year is long term
        /// </summary>
        /// <param name="PurchasedDate"> the date when purchased the stock</param>
        /// <returns>Short Term or Long Term</returns>
        public string GetTerm(DateTime PurchasedDate)
        {
            try
            {
                DateTime pdate = Convert.ToDateTime(PurchasedDate);
                if (pdate > System.DateTime.Today)
                { return "Invalid purchase date."; }
            }
            catch
            { return "Invalid purchase date."; }

            if (PurchasedDate >= System.DateTime.Today.AddYears(-1))
            { return "Short Term"; }
            else
            { return "Long Term"; }
        }

        /// <summary>
        /// function to calculate the current value of the investment:
        /// number of shares multiplied by the current price per share
        /// </summary>
        /// <param name="numShares">number of shares</param>
        /// <param name="currentPrice">the current price per share</param>
        /// <returns>total value</returns>
        public double CalculateCurrentValue(int numShares, double currentPrice)
        {
            return numShares * currentPrice;
        }
    }
}
