using System.ComponentModel.DataAnnotations;

namespace InvestmentPerformanceApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
