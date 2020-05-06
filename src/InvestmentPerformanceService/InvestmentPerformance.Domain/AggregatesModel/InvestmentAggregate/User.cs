using System;
namespace InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate
{
    public class User
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public User()
        {
        }
    }
}
