namespace InvestmentPerformanceApi.Models
{
    public class InvestmentPerformance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Shares { get; set; }
        public decimal CostBasisPerShare { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal CurrentPrice { get; set; }
        public Term Term { get; set; }
        public decimal NetGain { get; set; }
    }
}
