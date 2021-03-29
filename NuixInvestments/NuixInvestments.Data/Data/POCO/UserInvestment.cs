using System;

namespace NuixInvestments.MiddleWare.Data.POCO
{
    public class UserInvestment
    {
        public User User { get; set; }
        public Investment Investment { get; set; }

        public int UserId { get; set; }
        public int InvestmentId { get; set; }
        public decimal AveragePurchasePrice { get; set; }
        public int CurrentShares { get; set; }
        public decimal PriceAtChange { get; set; }
        public int ShareDifference { get; set; }
        public DateTime ChangeTimeStamp { get; set; }
    }
}
