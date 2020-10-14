using System;

namespace InvestmentPerformance.WebApi.Data.Entities
{
    public class UserInvestment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int InvestmentId { get; set; }

        public Investment Investment { get; set; }

        public int Shares { get; set; }

        public decimal CostBasis { get; set; }

        public DateTime DatePurchased { get; set; }        
    }
}
