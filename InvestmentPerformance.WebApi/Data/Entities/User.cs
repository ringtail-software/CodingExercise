using System.Collections.Generic;

namespace InvestmentPerformance.WebApi.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<UserInvestment> Investments { get; set; }
     }
}
