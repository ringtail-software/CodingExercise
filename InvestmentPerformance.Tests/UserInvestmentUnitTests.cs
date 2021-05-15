using Microsoft.EntityFrameworkCore;
using InvestmentPerformance.Api.Entities.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace InvestmentPerformance.Tests
{
    public class UserInvestmentUnitTests
    {
        private const string User1Id = "user1";

        [Fact]
        public async Task TestUserInvestmentTotalShares()
        {
            const int InvestmentId = 1;

            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestUserInvestmentTotalShares));

            var userInvestment = await dbContext.UserInvestments.Where(ui => ui.UserId == User1Id && ui.InvestmentId == InvestmentId).FirstAsync();

            dbContext.Dispose();

            Assert.Equal(125, userInvestment.TotalShares);
        }

        [Fact]
        public async Task TestUserInvestmentCurrentValue()
        {
            const int InvestmentId = 1;

            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestUserInvestmentCurrentValue));

            var userInvestment = await dbContext.UserInvestments.Where(ui => ui.UserId == User1Id && ui.InvestmentId == InvestmentId).FirstAsync();

            dbContext.Dispose();

            Assert.Equal(2562.5m, userInvestment.CurrentValue);
        }

        [Fact]
        public async Task TestUserInvestmentNegativeTotalGain()
        {
            const int InvestmentId = 1;

            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestUserInvestmentNegativeTotalGain));

            var userInvestment = await dbContext.UserInvestments.Where(ui => ui.UserId == User1Id && ui.InvestmentId == InvestmentId).FirstAsync();

            dbContext.Dispose();

            Assert.Equal(-200m, userInvestment.TotalGain);
        }

        [Fact]
        public async Task TestUserInvestmentTotalGain()
        {
            const int InvestmentId = 3;
            
            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestUserInvestmentTotalGain));

            var userInvestment = await dbContext.UserInvestments.Where(ui => ui.UserId == User1Id && ui.InvestmentId == InvestmentId).FirstAsync();

            dbContext.Dispose();

            Assert.Equal(7122m, userInvestment.TotalGain);
        }

        [Fact]
        public async Task TestUserInvestmentLongTerm()
        {
            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestUserInvestmentLongTerm));

            var userInvestment = await dbContext.UserInvestments.FirstAsync();

            dbContext.Dispose();

            userInvestment.CreatedDate = DateTime.UtcNow.AddYears(-1);
            Assert.Equal(Term.Long, userInvestment.Term);

            userInvestment.CreatedDate = DateTime.UtcNow.AddYears(-5);
            Assert.Equal(Term.Long, userInvestment.Term);
        }

        [Fact]
        public async Task TestUserInvestmentShortTerm()
        {
            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestUserInvestmentShortTerm));

            var userInvestment = await dbContext.UserInvestments.FirstAsync();
            dbContext.Dispose();

            userInvestment.CreatedDate = DateTime.UtcNow.AddYears(-1).AddHours(1);
            Assert.Equal(Term.Short, userInvestment.Term);

            userInvestment.CreatedDate = DateTime.UtcNow.AddHours(-1);
            Assert.Equal(Term.Short, userInvestment.Term);
        }
    }
}
