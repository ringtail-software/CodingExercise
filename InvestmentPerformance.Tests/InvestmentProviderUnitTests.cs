using InvestmentPerformance.Api.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InvestmentPerformance.Tests
{
    public class InvestmentProviderUnitTests
    {
        private const string User1Id = "user1";

        [Fact]
        public async Task TestGetActiveUserInvestmentsCount()
        {
            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestGetActiveUserInvestmentsCount));
            var investmentProvider = new InvestmentProvider(dbContext);

            var investments = await investmentProvider.GetActiveUserInvestments(User1Id, CancellationToken.None);
            
            dbContext.Dispose();

            Assert.Equal(2, investments.Count());
        }

        [Fact]
        public async Task TestGetActiveUserInvestmentsInvestmentIds()
        {
            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestGetActiveUserInvestmentsInvestmentIds));
            var investmentProvider = new InvestmentProvider(dbContext);

            var investments = await investmentProvider.GetActiveUserInvestments(User1Id, CancellationToken.None);

            dbContext.Dispose();

            var investmentIds = investments.Select(i => i.Id).ToArray();
            var expected = new int[] { 1, 3 };

            Assert.Equal(investmentIds, expected);
        }

        [Fact]
        public async Task TestGetUserInvestmentValid()
        {
            const int InvestmentId = 1;

            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestGetUserInvestmentValid));
            var investmentProvider = new InvestmentProvider(dbContext);

            var userInvestmentModel = await investmentProvider.GetUserInvestment(User1Id, InvestmentId, CancellationToken.None);

            dbContext.Dispose();

            Assert.NotNull(userInvestmentModel);
            Assert.Equal(InvestmentId, userInvestmentModel.Id);
        }

        [Fact]
        public async Task TestGetUserInvestmentNotActive()
        {
            const int InvestmentId = 4;

            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestGetUserInvestmentNotActive));
            var investmentProvider = new InvestmentProvider(dbContext);

            var userInvestmentModel = await investmentProvider.GetUserInvestment(User1Id, InvestmentId, CancellationToken.None);

            dbContext.Dispose();

            Assert.Null(userInvestmentModel);
        }

        [Fact]
        public async Task TestGetUserInvestmentNotExists()
        {
            const int InvestmentId = 100;

            var dbContext = DbContextMocker.GetInvestmentPerformanceDbContext(nameof(TestGetUserInvestmentNotExists));
            var investmentProvider = new InvestmentProvider(dbContext);

            var userInvestmentModel = await investmentProvider.GetUserInvestment(User1Id, InvestmentId, CancellationToken.None);

            dbContext.Dispose();

            Assert.Null(userInvestmentModel);
        }
    }
}
