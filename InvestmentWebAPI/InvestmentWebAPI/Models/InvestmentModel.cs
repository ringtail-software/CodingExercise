using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investment.API.Models
{
    public class InvestmentModel
    {
        public long InvestmentId { get; set; }

        public string InvestmentName { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal Shares { get; set; }

        public string SecuritySymbol { get; set; }

    }
}
