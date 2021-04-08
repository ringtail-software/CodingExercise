using System;

namespace RingTail {
    public class Bond : IInvestment {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameReadable { get; set; }
        public InvestmentType InvestmentType => InvestmentType.Bond;
        public decimal Rate { get; set; }
        public decimal CostBasis { get; set; }
        public decimal InitialValue => CostBasis;
        public decimal CurrentValue => CostBasis * (1 + Rate);
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