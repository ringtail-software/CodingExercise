using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    /// <summary>
    /// this class will handle all investment data calculations,
    /// and assume all data will stored in a SQL server database, 
    /// call the data access layer to retieve the data from database
    /// </summary>
    public class Investment
    {
        public int InvestorID { get; set; }
        private int _investmentID; //stockID
        private int _numShares;  //number of stock shares purchased
        private double _basicCostPerShare; //the cost per share when purchased it
        public string Term;//how long the stock has been owned. <=1 year is short term, >1 year is long term
        public DateTime PurchasedOn { get; set; } //the date the investment was purchased
        public double CurrentPrice{ get; set; }//the investment stock current price per share
        public double CurrentValue;//Total valude of the investment currently: number of shares multiplied by the current price per share
        public double TotalLostGains;//the difference between the current value, and the amount paid for all shares when they were purchased
        public Investment()
        { }

        public Investment(int investmentID)
        {
            this._investmentID = investmentID;

        }

        public int InvestmentID
        {
            get { return _investmentID; }
            set { _investmentID = value; }
        }

        public int NumShares
        {
            get { return _numShares; }
            set { _numShares = value; }
        }

        public double BasicCostPerShare
        {
            get { return _basicCostPerShare; }
            set { _basicCostPerShare = value; }
        }
    }
}
