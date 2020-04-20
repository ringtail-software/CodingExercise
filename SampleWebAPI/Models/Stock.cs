// Data describing the stock/investment

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
