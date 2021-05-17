using System;

namespace InvestmentPerformance.Api.Features.Shared.Models
{
    public class GetInvestmentPurchaseModel
    {
        public decimal CostBasisPerShare { get; set; }
        public int NumberOfShares { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
