using System.ComponentModel.DataAnnotations;

namespace InvestmentAPI.Models
{
    public class InvestmentDetail
    {
        [Key]
        public int SystemId { get; set; }
        public int InvestmentId { get; set; }
        public int Shares { get; set; }
        public double CostBasisPerShare { get; set; }
        public double CurrentPrice { get; set; }
        public double CurrentValue { get; set; }
        public byte Term { get; set; }
        public double NetValuation { get; set; }
    }
}

