using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentPerformance.Dtos
{
    public class InvestmentTransactionDto
    {
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public int InvestmentId { get; set; }
        public double PurchasedPrice { get; set; }
        public DateTime PurchasedTimeStamp { get; set; }
        public string Name { get; set; }
        public int Shares { get; set; }
    }
}
