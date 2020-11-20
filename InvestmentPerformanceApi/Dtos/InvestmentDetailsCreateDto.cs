using System;
using System.ComponentModel.DataAnnotations;

namespace InvestmentPerformanceApi.Dtos
{
    public class InvestmentDetailsCreateDto
    {
        [Required]
        public decimal CostBasis { get; set; }
        [Required]
        public int Shares { get; set; }
        [Required]
        public decimal CurrentPrice { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
