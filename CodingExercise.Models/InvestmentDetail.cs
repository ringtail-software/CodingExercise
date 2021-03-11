using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Models
{
    public class InvestmentDetail : LinkedResource
    {
        // The query should return number of shares, cost basis per share, current value, current price, term, and total gain/loss
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumShares { get; set; }
        public string CostBasisPerShare { get; set; }
        public string CurrentValue { get; set; }
        public string CurrentPrice { get; set; }
        public string Term { get; set; }
        public string TotalGainLoss { get; set; }
        public InvestmentDetail() { }
        public override bool Equals(object obj)
        {
            if (!(obj is InvestmentDetail))
                return false;
            var val = (InvestmentDetail)obj;
            return Id == val.Id && Name == val.Name && NumShares == val.NumShares && CostBasisPerShare == val.CostBasisPerShare && CurrentValue == val.CurrentValue 
                && CurrentPrice == val.CurrentPrice && Term == val.Term && TotalGainLoss == val.TotalGainLoss && Links.Equals(val.Links);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, NumShares, CostBasisPerShare, CurrentValue, CurrentPrice, Term, TotalGainLoss);
        }
    }
}
