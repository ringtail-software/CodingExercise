using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using InvestmentPerformance.Domain.SeedWork;

namespace InvestmentPerformance.Domain.AggregatesModel
{
    /// <summary>
    /// The context boundary for this microservice
    /// </summary>
    public class Investment : IAggregateRoot
    {
        protected Investment() {}

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int UserId { get; private set; }

        // Details - below data (details) could be managed in a different class/table but since the relationship would be one-to-one...
        // ...and I dont know how UI creates investments, it makes sense to keep it here.

        public int NumberOfShares { get; private set; }

        public decimal CostBasisPerShare { get; private set; }

        public decimal CurrentValue { get; private set; }

        public decimal CurrentPrice { get; private set; }

        public decimal Term { get; private set; }

        public decimal TotalGainOrLoss { get; private set; }

        public string TermLength
        {
            get
            {
                return (this.Term <= 1) ? Terms.Short.ToString() : Terms.Long.ToString();
            }
        }

        public Investment(int id, string name, int userId, int numberOfShares, decimal costBasisPerShare, decimal currentValue,
                          decimal currentPrice, decimal term, decimal totalGainOrLoss)
        {
            this.Id = id;
            this.Name = name;
            this.UserId = userId;
            this.NumberOfShares = numberOfShares;
            this.CostBasisPerShare = costBasisPerShare;
            this.CurrentValue = currentValue;
            this.CurrentPrice = currentPrice;
            this.Term = term;
            this.TotalGainOrLoss = totalGainOrLoss;
        }

        /// <summary>
        /// Entity behavior logic, for when a share is bought
        /// </summary>
        public void Buy(int sharesBought)
        {
            this.NumberOfShares = this.NumberOfShares + sharesBought;
            this.CalculateCostBasisPerShare();
        }

        private void CalculateCostBasisPerShare()
        {
            this.CostBasisPerShare = this.CurrentPrice * this.NumberOfShares;
        }

        /// <summary>
        /// Entity behavior logic, for when a share is sold
        /// </summary>
        public void Sell(int sharesSold)
        {
            this.NumberOfShares = this.NumberOfShares - sharesSold;
            this.CalculateCostBasisPerShare();
        }

        /// <summary>
        /// Entity behavior logic, for when a deposit is made
        /// </summary>
        public void Deposit()
        {
            
        }

        /// <summary>
        /// Entity behavior logic, for when a withdrawal happens
        /// </summary>
        public void Withdrawal()
        {

        }
    }
}
