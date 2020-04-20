// Data represents each unique investment purchase

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    public class Investment
    {
        // Unique Id for this purchase
        public int Id { get; set; }

        // Stock class object: contains stock Symbol and Name
        public Stock Stock { get; set; }

        // The price of the stock  at the time of purchase
        public decimal PurchasePrice { get; set; }

        // The date of the stock purchase
        public DateTime PurchaseDate { get; set; }

        // The number of shares purchased
        public int Quantity { get; set; }

        // The client that made the purchase
        public int ClientOwnerId { get; set; }
    }
}
