using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentPerformanceApi.Models
{
    public class Investments
    {
        [Key]
        public int InvestmentId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [Required]
        public string CompanyName { get; set; }

    }
}
