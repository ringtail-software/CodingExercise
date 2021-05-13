using InvestmentPerformance.Api.Entities.Enums;
using System.Collections.Generic;

namespace InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment.Models
{
    public class GetInvestmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfShares { get; set; }
        public IEnumerable<GetInvestmentPurchaseModel> Purchases { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal CurrentPrice { get; set; }
        public Term Term { get; set; }
        public decimal TotalGain { get; set; }
    }
}
