using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuixApi.Models
{
    public class InvestmentDetails
    {
        public int Id { get; set; }
        public int NumberOfSharesOwned { get; set; }
        public  DateTime DatePurchased { get; set; } 
        public double PriceWhenPurchased { get; set; }
        public double CurrentPrice { get; set; }
    
    }
}
