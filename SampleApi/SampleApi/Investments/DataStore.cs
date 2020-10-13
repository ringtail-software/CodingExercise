using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Investments
{
    // assumption: this would normally be a database.
    public static class DataStore
    {
        public static IEnumerable<Stock> Stocks => new Stock[] {
                    new Stock(1, "Microsoft", 100),
                    new Stock(2, "Apple", 200),
                    new Stock(3, "Amazon", 300.1),
                };

        public static IEnumerable<InvestmentTransaction> InvestmentTransactions => new InvestmentTransaction[]{
                new InvestmentTransaction(1, 1, new DateTime(2020,10,5), 1, "Microsoft", 5, 95.5),
                new InvestmentTransaction(2, 1, new DateTime(2020,6,5), 1, "Microsoft", 5, 80),
                new InvestmentTransaction(3, 1, new DateTime(2019,7,5), 2, "Apple", 15, 220),
                new InvestmentTransaction(4, 2, new DateTime(2020,10,5), 2, "Apple", 5, 180),
                new InvestmentTransaction(5, 2, new DateTime(2018,5,5), 3, "Amazon", 5, 10),
            };
    }

    //assumption: there must be a stock object, if an investment is a purchase of a given stock
    public class Stock
    {
        public Stock(int id, string name, double price)
        {
            StockId = id;
            StockName = name;
            CurrentStockPrice = price;
        }
        public int StockId { get; set; }
        public string StockName { get; set; }
        public double CurrentStockPrice { get; set; }
    }

    //assumption: there must be an investment transaction object
    public class InvestmentTransaction
    {
        public InvestmentTransaction(int transactionId, int userId, DateTime date, int stockId, string stockName, double qty, double cost)
        {
            TransactionId = transactionId;
            UserId = userId;
            TransactionDate = date;
            StockId = stockId;
            StockName = stockName;
            ShareQuantity = qty;
            CostPerShare = cost;
        }
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int StockId { get; set; }
        public string StockName { get; set; }
        public double ShareQuantity { get; set; }
        public double CostPerShare { get; set; }
    }

    //assumption: there must be users
    /*public class AppUsers
    {
        public AppUsers(int id, string name)
        {
            UserId = id;
            Name = name;
        }
        public int UserId { get; set; }
        public string Name { get; set; }
    }*/
}
