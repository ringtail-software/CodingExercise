using Microsoft.EntityFrameworkCore;
using InvestmentPerformance.Api.Entities.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using InvestmentPerformance.Api.Entities;

namespace InvestmentPerformance.Tests
{
    public class UserInvestmentUnitTests : DbContextTestBase
    {
        [Fact]
        public async Task TestUserInvestmentTotalShares()
        {
            const int InvestmentId = DatabaseSeeder.Investment1Id;
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var userInvestment = await dbContext
                    .UserInvestments
                    .Include(ui => ui.Investment)
                    .Include(ui => ui.Purchases)
                    .Where(ui => ui.UserId == UserId && ui.InvestmentId == InvestmentId).FirstAsync();

                Assert.Equal(125, userInvestment.TotalShares);
            }
        }

        [Fact]
        public async Task TestUserInvestmentCurrentValue()
        {
            const int InvestmentId = DatabaseSeeder.Investment1Id;
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var userInvestment = await dbContext
                    .UserInvestments
                    .Include(ui => ui.Investment)
                    .Include(ui => ui.Purchases)
                    .Where(ui => ui.UserId == UserId && ui.InvestmentId == InvestmentId).FirstAsync();

                Assert.Equal(2562.5m, userInvestment.CurrentValue);
            }
        }

        [Fact]
        public async Task TestUserInvestmentNegativeTotalGain()
        {
            const int InvestmentId = DatabaseSeeder.Investment1Id;
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var userInvestment = await dbContext
                    .UserInvestments
                    .Include(ui => ui.Investment)
                    .Include(ui => ui.Purchases)
                    .Where(ui => ui.UserId == UserId && ui.InvestmentId == InvestmentId).FirstAsync();

                Assert.Equal(-200m, userInvestment.TotalGain);
            }
        }

        [Fact]
        public async Task TestUserInvestmentTotalGain()
        {
            const int InvestmentId = DatabaseSeeder.Investment3Id;
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var userInvestment = await dbContext
                    .UserInvestments
                    .Include(ui => ui.Investment)
                    .Include(ui => ui.Purchases)
                    .Where(ui => ui.UserId == UserId && ui.InvestmentId == InvestmentId).FirstAsync();

                Assert.Equal(7122m, userInvestment.TotalGain);
            }
        }

        [Fact]
        public void TestUserInvestmentLongTerm()
        {
            var userInvestment = new UserInvestment();

            userInvestment.CreatedDate = DateTime.UtcNow.AddYears(-1);
            Assert.Equal(Term.Long, userInvestment.Term);

            userInvestment.CreatedDate = DateTime.UtcNow.AddYears(-5);
            Assert.Equal(Term.Long, userInvestment.Term);
        }

        [Fact]
        public void TestUserInvestmentShortTerm()
        {
            var userInvestment = new UserInvestment();

            userInvestment.CreatedDate = DateTime.UtcNow.AddYears(-1).AddHours(1);
            Assert.Equal(Term.Short, userInvestment.Term);

            userInvestment.CreatedDate = DateTime.UtcNow.AddHours(-1);
            Assert.Equal(Term.Short, userInvestment.Term);
        }
    }
}
