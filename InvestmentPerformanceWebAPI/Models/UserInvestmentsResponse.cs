namespace InvestmentPerformance.WebAPI.Models
{
    public class UserInvestmentsResponse
    {
        public int? InvestmentId { get; set; }
        public string Name { get; set; }
        public decimal? ShareCount { get; set; }
        public decimal? CostBasis { get; set; }
        public decimal? CurrentPrice { get; set; }
        public string Term { get; set; }
        public decimal? TotalGain { get; set; }
    }
}
