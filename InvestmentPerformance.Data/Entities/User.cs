using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestmentPerformance.Data.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserInvestment> UserInvestments { get; set; }
    }
}
