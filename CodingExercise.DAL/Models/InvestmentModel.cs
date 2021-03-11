using System;

namespace CodingExercise.DAL.Models
{
    public class InvestmentModel
    {
        /*
         * Cost basis per share: this is the price of 1 share of stock at the time it was purchased

         * Current value: this is the number of shares multiplied by the current price per share

         * Current price: this is the current price of 1 share of the stock

         * Term: this is how long the stock has been owned. <=1 year is short term, >1 year is long term

         * Total gain or loss: this is the difference between the current value, and the amount paid for all shares when they were purchase
         */
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceAtPurchase { get; set; }
        public int NumShares { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is InvestmentModel))
                return false;
            var val = (InvestmentModel)obj;
            return Id == val.Id && Name == val.Name && PriceAtPurchase == val.PriceAtPurchase && NumShares == val.NumShares && CurrentPrice == val.CurrentPrice && PurchaseDate == val.PurchaseDate;
        }
    }
}
