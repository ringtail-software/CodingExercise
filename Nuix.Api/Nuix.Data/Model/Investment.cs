using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuix.Data.Model
{
    public class Investment
    {
        public int Id { get; set; }

        // Investment name.
        public string Name { get; set; }

        // This is the price of 1 share of stock at the time it was purchased.
        public decimal CostBasisPerShare { get; set; }


        // This is the number of shares multiplied by the current price per share.
        public decimal CurrentValue => NumberOfShares * CurrentPrice;

        public decimal NumberOfShares { get; set; }

        // This is the current price of 1 share of the stock.
        public decimal CurrentPrice { get; set; }

        // This is how long the stock has been owned. <=1 year is short term, >1 year is long term.
        public int Term => DateTime.Now.Year - PurchaseDate.Year;

        //
        // Total gain or loss:
        //   this is the difference between the current value,
        //   and the amount paid for all shares when they were purchased.
        //
        public decimal TotalGainOrLoss => CurrentValue - OriginalValue;

        private decimal OriginalValue => NumberOfShares * CostBasisPerShare;

        public DateTime PurchaseDate { get; set; }
    }
}