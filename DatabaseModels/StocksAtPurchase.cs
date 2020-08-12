using System;

namespace KrummertNuix.DatabaseModels
{
    public class StocksAtPurchase
    {
        public Guid Id { get; set; }
        public Guid StocksAtCurrentId { get; set; }
        public double PricePerShare { get; set; }
        public int QtySharesPurchased { get; set; }
        public DateTime DatePurchased { get; set; }

        public StocksAtCurrent StocksAtCurrent { get; set; }
    }
} 