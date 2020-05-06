using System;
using InvestmentPerformance.Domain.SeedWork;

namespace InvestmentPerformance.Domain.AggregatesModel
{
    public class Investment : Entity, IAggregateRoot
    {
        protected Investment() {}

        public string Name { get; private set; }

        public DateTime DateCreated { get; private set; }

        public int UserId { get; private set; }

        public Investment(int id, string name, DateTime dateCreated, int userId)
        {
            this.Id = id;
            this.Name = name;
            this.DateCreated = dateCreated;
            this.UserId = userId;
        }
    }
}
