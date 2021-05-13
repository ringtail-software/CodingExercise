using InvestmentPerformance.Api.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentPerformance.Api.Entities
{
    public class UserInvestment : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public int InvestmentId { get; set; }
        public Investment Investment { get; set; }

        public bool Active { get; set; }

        private readonly List<Purchase> _purchases = new List<Purchase>();
        public IReadOnlyCollection<Purchase> Purchases => _purchases.AsReadOnly();

        public int TotalShares => Purchases.Sum(p => p.NumberOfShares);

        public decimal CurrentValue => Purchases.Sum(p => p.NumberOfShares * Investment.CurrentPrice);

        public decimal TotalGain => CurrentValue - Purchases.Sum(p => p.NumberOfShares * p.CostBasisPerShare);

        public Term Term => DateTime.UtcNow.AddYears(-1) <= CreatedDate ? Term.Short : Term.Long;
    }
}
