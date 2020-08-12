using System;

namespace KrummertNuix.DatabaseModels
{
    public class StocksAtCurrent
    {
        public Guid Id { get; set; }
        public double PricePerShare { get; set; }
        public string Name { get; set; }
    }
} 