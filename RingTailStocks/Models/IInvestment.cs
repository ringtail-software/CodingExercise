using System;

namespace RingTail {
    public interface IInvestment {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameReadable { get; set; }
        public InvestmentType InvestmentType { get; }
        public decimal CostBasis { get; set; }
        public decimal InitialValue { get; }
        public decimal CurrentValue { get; }
        public DateTime AcquiredDate { get; set; }
        public decimal TotalDelta { get; }
        public InvestmentTerm Term { get; }
    }

    public enum InvestmentType {
        Stock,
        Bond,
        MutualFund
    }

    public enum InvestmentTerm {
        ShortTerm,
        LongTerm
    }
}