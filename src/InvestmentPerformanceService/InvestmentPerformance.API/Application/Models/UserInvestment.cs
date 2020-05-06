using System;
namespace InvestmentPerformance.API.Application.Models
{
    /// <summary>
    /// View Model that holds only id and name for a user specific investment
    /// </summary>
    public class UserInvestment
    {
        public UserInvestment() { }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
