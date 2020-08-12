using System;
using System.Collections.Generic;

namespace KrummertNuix.DatabaseModels
{
    public class Portfolio
    {
        public Guid Id { get; set; }
        public Guid MyUserId { get; set; }
        public Guid StocksAtPurchaseId { get; set; }
        public string Name { get; set; }
        
        public StocksAtPurchase StocksAtPurchase { get; set; }
    }
} 