namespace InvestmentPerformance.Api.Entities
{
    public class Purchase : BaseEntity
    {
        public int Id { get; set; }
        
        public int UserInvestmentId { get; set; }
        public UserInvestment UserInvestment { get; set; }

        public decimal CostBasisPerShare { get; set; }
        public int NumberOfShares { get; set; }
    }
}
