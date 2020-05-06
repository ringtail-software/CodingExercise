using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using InvestmentPerformance.Domain.SeedWork;

namespace InvestmentPerformance.Domain.AggregatesModel
{
    public class InvestmentDetail : Entity
    {
        protected InvestmentDetail() {}

        public int InvestmentId { get; private set; }

        public decimal CostBasisPerShare { get; private set; }

        public int CurrentValue { get; private set; }

        public decimal CurrentPrice { get; private set; }

        public Term Term { get; private set; }

        public decimal TotalGainOrLoss { get; private set; }
    }
}
