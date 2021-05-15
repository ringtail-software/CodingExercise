using InvestmentPerformance.Api.Entities;

namespace InvestmentPerformance.Tests
{
    public static class DbContextExtensions
    {
        public static void Seed(this InvestmentPerformanceDbContext dbContext)
        {

            // Investments
            dbContext.Investments.Add(new Investment { Id = 1, Name = "INVEST1", CurrentPrice = 20.5m });
            dbContext.Investments.Add(new Investment { Id = 2, Name = "INVEST2", CurrentPrice = 10m });
            dbContext.Investments.Add(new Investment { Id = 3, Name = "INVEST3", CurrentPrice = 100m });
            dbContext.Investments.Add(new Investment { Id = 4, Name = "INVEST4", CurrentPrice = 10.5m });

            // UserInvestments
            dbContext.UserInvestments.Add(new UserInvestment { Id = 1, UserId = "user1", InvestmentId = 1, Active = true });
            dbContext.UserInvestments.Add(new UserInvestment { Id = 2, UserId = "user1", InvestmentId = 3, Active = true });
            dbContext.UserInvestments.Add(new UserInvestment { Id = 3, UserId = "user1", InvestmentId = 4, Active = false });

            dbContext.UserInvestments.Add(new UserInvestment { Id = 4, UserId = "user2", InvestmentId = 1, Active = true });
            dbContext.UserInvestments.Add(new UserInvestment { Id = 5, UserId = "user2", InvestmentId = 2, Active = false });

            dbContext.UserInvestments.Add(new UserInvestment { Id = 6, UserId = "user3", InvestmentId = 1, Active = true });
            dbContext.UserInvestments.Add(new UserInvestment { Id = 7, UserId = "user3", InvestmentId = 4, Active = true });

            // Purchases
            // user1 purchases
            dbContext.Purchases.Add(new Purchase { Id = 1, UserInvestmentId = 1, CostBasisPerShare = 10.5m, NumberOfShares = 25 });
            dbContext.Purchases.Add(new Purchase { Id = 2, UserInvestmentId = 1, CostBasisPerShare = 25m, NumberOfShares = 100 });

            dbContext.Purchases.Add(new Purchase { Id = 3, UserInvestmentId = 2, CostBasisPerShare = 20m, NumberOfShares = 20 });
            dbContext.Purchases.Add(new Purchase { Id = 4, UserInvestmentId = 2, CostBasisPerShare = 10.5m, NumberOfShares = 50 });
            dbContext.Purchases.Add(new Purchase { Id = 5, UserInvestmentId = 2, CostBasisPerShare = 30.2m, NumberOfShares = 15 });            
            
            dbContext.Purchases.Add(new Purchase { Id = 6, UserInvestmentId = 3, CostBasisPerShare = 10.98m, NumberOfShares = 55 });

            // user2 purchases
            dbContext.Purchases.Add(new Purchase { Id = 7, UserInvestmentId = 4, CostBasisPerShare = 31.00m, NumberOfShares = 45 });

            dbContext.SaveChanges();
        }
    }
}
