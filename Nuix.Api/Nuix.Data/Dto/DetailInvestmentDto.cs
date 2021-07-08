namespace Nuix.Data.Dto
{
    public class DetailInvestmentDto
    {
        public decimal NumberOfShares { get; set; }

        public decimal CostBasisPerShare { get; set; }

        public decimal CurrentValue { get; set; }
        
        public decimal CurrentPrice { get; set; }

        public int Term { get; set; }
        public decimal TotalGainOrLoss { get; set; }
    }
}
