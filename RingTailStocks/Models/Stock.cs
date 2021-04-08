using System;

namespace RingTail {
    public class Stock : IInvestment {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameReadable { get; set; }
        public InvestmentType InvestmentType => InvestmentType.Stock;
        public decimal CostBasis { get; set; }

        public decimal InitialValue => CostBasis * Shares;

        public decimal CurrentValue => Price * Shares;

        public decimal Price { get; set; }
        public int Shares { get; set; }

        public DateTime AcquiredDate { get; set; }
        public decimal TotalDelta => CurrentValue - InitialValue;

        public InvestmentTerm Term {
            get {
                var lastYear = DateTime.Now.AddYears(-1);
                return lastYear.CompareTo(AcquiredDate) > 0 ? InvestmentTerm.LongTerm : InvestmentTerm.ShortTerm;
            }
        }
    }
}