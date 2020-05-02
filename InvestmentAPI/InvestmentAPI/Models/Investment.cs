using System;
using System.ComponentModel.DataAnnotations;

namespace InvestmentAPI.Models
{
    public class Investment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime TimeOfPurchase { get; set; }
    }
}
