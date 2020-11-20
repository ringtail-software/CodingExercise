using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentPerformanceApi.Models
{
    public class InvestmentDetails
    {
        [Key]
        public int InvestmentId { get; set; }
        [Required]
        public decimal CostBasis { get; set; }
        public int Shares { get; set; }
        public decimal CurrentValue => Shares * CurrentPrice;
        [Required]
        public decimal CurrentPrice { get; set; }
        public bool ShortTerm => PurchaseDate.CompareTo(DateTime.UtcNow.AddYears(-1)) < 0;
        public DateTime PurchaseDate { get; set; }
        [ForeignKey("CompanyName")]
        public string CompanyName { get; set; }
        public int UserId { get; set; }
    }
}
