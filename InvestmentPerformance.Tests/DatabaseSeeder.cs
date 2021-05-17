using InvestmentPerformance.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.Tests
{
    public static class DatabaseSeeder
    {
        public const string User1Id = "testUser1";
        public const string User2Id = "testUser2";

        public const int Investment1Id = 5000;
        public const int Investment2Id = 5001;
        public const int Investment3Id = 5002;
        public const int Investment4Id = 5003;

        public static void Seed(InvestmentPerformanceDbContext dbContext)
        {
            // Investments
            var investment1 = new Investment { Id = Investment1Id, Name = "TEST_INVEST1", CurrentPrice = 20.5m };
            var investment2 = new Investment { Id = Investment2Id, Name = "TEST_INVEST2", CurrentPrice = 10m };
            var investment3 = new Investment { Id = Investment3Id, Name = "TEST_INVEST3", CurrentPrice = 100m };
            var investment4 = new Investment { Id = Investment4Id, Name = "TEST_INVEST4", CurrentPrice = 10.5m };

            // UserInvestments
            var user1Investment1 = new UserInvestment { UserId = User1Id, Investment = investment1, Active = true };
            var user1Investment3 = new UserInvestment { UserId = User1Id, Investment = investment3, Active = true };
            var user1Investment4 = new UserInvestment { UserId = User1Id, Investment = investment4, Active = false };

            var user2Investment1 = new UserInvestment { UserId = User2Id, Investment = investment1, Active = true };
            var user2Investment2 = new UserInvestment { UserId = User2Id, Investment = investment2, Active = false };

            // Purchases
            // User1 purchases
            user1Investment1.AddPurchase(new Purchase { CostBasisPerShare = 10.5m, NumberOfShares = 25 });
            user1Investment1.AddPurchase(new Purchase { CostBasisPerShare = 25m, NumberOfShares = 100 });

            user1Investment3.AddPurchase(new Purchase { CostBasisPerShare = 20m, NumberOfShares = 20 });
            user1Investment3.AddPurchase(new Purchase { CostBasisPerShare = 10.5m, NumberOfShares = 50 });
            user1Investment3.AddPurchase(new Purchase { CostBasisPerShare = 30.2m, NumberOfShares = 15 });

            user1Investment4.AddPurchase(new Purchase { CostBasisPerShare = 10.98m, NumberOfShares = 55 });

            // User2 purchases
            user2Investment1.AddPurchase(new Purchase { CostBasisPerShare = 31.00m, NumberOfShares = 45 });

            dbContext.UserInvestments.AddRange(new[] {
                user1Investment1,
                user1Investment3,
                user1Investment4,

                user2Investment1,
                user2Investment2
            });

            dbContext.SaveChanges();
        }
    }
}
