using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    /// <summary>
    /// this is a mock up database
    /// </summary>
    public class InvestmentDatabase
    {
        List<Investor> investors = new List<Investor>();
        List<Stock> stocks = new List<Stock>();
        List<Investment> investments = new List<Investment>();

        /// <summary>
        /// create some testing data
        /// </summary>
        public InvestmentDatabase()
        {
            investors.Add(new Investor { InvestorID = 1, InvestorName = "Investor1" });
            investors.Add(new Investor { InvestorID = 2, InvestorName = "Investor2" });

            stocks.Add(new Stock { ID = 1, Name = "stock1" });
            stocks.Add(new Stock { ID = 2, Name = "stock2" });
            stocks.Add(new Stock { ID = 3, Name = "stock3" });

            investments.Add(new Investment { InvestmentID = 1, InvestorID = 1, NumShares = 5, BasicCostPerShare = 10.5, PurchasedOn = Convert.ToDateTime("11/28/2019"), CurrentPrice = 12.4 });
            investments.Add(new Investment { InvestmentID = 2, InvestorID = 1, NumShares = 10, BasicCostPerShare = 15.5, PurchasedOn = Convert.ToDateTime("10/28/2018"), CurrentPrice = 10.6 });
            investments.Add(new Investment { InvestmentID = 3, InvestorID = 2, NumShares = 3, BasicCostPerShare = 20.5, PurchasedOn = Convert.ToDateTime("9/28/2020"), CurrentPrice = 25.4 });
        }

        public InvestmentDatabase(Investor investor)
        {
            this.investors.Add(investor);
        }

        public InvestmentDatabase(Investor investor, Stock stock, Investment investment)
        {
            this.investors.Add(investor);
            this.stocks.Add(stock);
            this.investments.Add(investment);
        }

        public void AddInvestor(Investor investor)
        { this.investors.Add(investor); }

        public void AddStock(Stock stock)
        { this.stocks.Add(stock); }

        public void AddInvestment(Investment investment)
        { this.investments.Add(investment); }

        /// <summary>
        /// search the database and return the investments for the investor
        /// Assumption, the system has a relational database, 
        /// and there is a stored procedure which accept investor ID 
        /// and return a list of invested stocks with Id and name by the investor.
        /// the investment stocks will be put to a stock list 
        /// if the investor is not in the database, throw an invalid investor ID error.
        /// </summary>
        /// <param name="investorID"></param>
        /// <returns>a list of stocks</returns>
        public List<Stock> GetInvestments(int investorID)
        {
            List<Stock> ret = new List<Stock>();
            try
            {
                foreach (Investment investment in this.investments)
                {
                    if (investment.InvestorID == investorID)
                    {
                        ret.Add(this.stocks.Find(item => item.ID == investment.InvestmentID));
                    }
                }
                if(ret.Count ==0 && this.investors.Find(item=> item.InvestorID== investorID) == null)
                { throw new Exception("Invalid Investor ID"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        /// <summary>
        /// search the database and return the investment details for the investor investment
        /// Assumption: the system has a relational database, 
        /// and there is a stored procedure which accept investor ID and stock ID 
        /// it will return the investment detail of the stock invested by the investor.
        /// the investment detail will be put into a investment object
        /// </summary>
        /// <param name="investorID"></param>
        /// <param name="investmentID"></param>
        /// <returns>Investment object</returns>
        public Investment GetInvestmentByID(int investorID, int investmentID)
        {
            Investment ret = null;
            try
            {
                foreach (Investment investment in this.investments)
                {
                    if (investment.InvestorID == investorID && investment.InvestmentID == investmentID)
                    {
                        ret = investment;
                        break;
                    }
                }
               
               if(ret == null)
                { 
                    if(this.investors.Find(item => item.InvestorID == investorID) == null)
                    throw new Exception("Invalid Investor ID");
                    else if (this.stocks.Find(item => item.ID == investmentID) == null)
                        throw new Exception("Invalid Investment ID");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        

    }
}

