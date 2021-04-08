using System;

namespace RingTail {
    public class MutualFund : IInvestment{
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameReadable { get; set; }
        public InvestmentType InvestmentType => InvestmentType.MutualFund;
        public decimal CostBasis { get; set; }
        public decimal InitialValue { get; }
        public decimal CurrentValue { get; }
        public DateTime AcquiredDate { get; set; }
        public decimal TotalDelta => CurrentValue - InitialValue;
        public InvestmentTerm Term {
            get {
                if ((DateTime.Now - AcquiredDate).TotalDays > 365) {
                    return InvestmentTerm.LongTerm;
                }

                return InvestmentTerm.ShortTerm;
            }
        }
    }
}