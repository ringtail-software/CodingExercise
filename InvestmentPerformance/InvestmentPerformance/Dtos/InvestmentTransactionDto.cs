using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentPerformance.Dtos
{
    public class InvestmentTransactionDto
    {
        public int TransactionId { get; set; }
        public int InvestmentId { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime PurchaseTimeStamp { get; set; }
        public string Name { get; set; }
        public int Shares { get; set; }
    }
}
