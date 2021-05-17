using InvestmentPerformance.Api.Entities;
using InvestmentPerformance.Api.Features.Shared.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InvestmentPerformance.Tests
{
    public class InvestmentProviderUnitTests : DbContextTestBase
    {
        [Fact]
        public async Task TestGetActiveUserInvestmentsCount()
        {
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            { 
                var investmentProvider = new InvestmentProvider(dbContext);
                var investments = await investmentProvider.GetActiveUserInvestments(UserId, CancellationToken.None);

                Assert.Equal(2, investments.Count());
            }
        }

        [Fact]
        public async Task TestGetActiveUserInvestmentsInvestmentIds()
        {
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var investmentProvider = new InvestmentProvider(dbContext);
                var investments = await investmentProvider.GetActiveUserInvestments(UserId, CancellationToken.None);

                var investmentIds = investments.Select(i => i.Id).ToArray();

                Assert.Contains(DatabaseSeeder.Investment1Id, investmentIds);
                Assert.Contains(DatabaseSeeder.Investment3Id, investmentIds);
            }
        }

        [Fact]
        public async Task TestGetUserInvestmentValid()
        {
            const int InvestmentId = DatabaseSeeder.Investment1Id;
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var investmentProvider = new InvestmentProvider(dbContext);
                var userInvestmentModel = await investmentProvider.GetUserInvestment(UserId, InvestmentId, CancellationToken.None);

                Assert.NotNull(userInvestmentModel);
                Assert.Equal(InvestmentId, userInvestmentModel.Id);
            }
        }

        [Fact]
        public async Task TestGetUserInvestmentNotActive()
        {
            const int InvestmentId = DatabaseSeeder.Investment4Id;
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var investmentProvider = new InvestmentProvider(dbContext);
                var userInvestmentModel = await investmentProvider.GetUserInvestment(UserId, InvestmentId, CancellationToken.None);

                Assert.Null(userInvestmentModel);
            }
        }

        [Fact]
        public async Task TestGetUserInvestmentNotExists()
        {
            const int InvestmentId = 100; // doesn't exist
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var investmentProvider = new InvestmentProvider(dbContext);
                var userInvestmentModel = await investmentProvider.GetUserInvestment(UserId, InvestmentId, CancellationToken.None);

                Assert.Null(userInvestmentModel);
            }
        }

        [Fact]
        public async Task TestGetUserInvestmentNonExistentUser()
        {
            const int InvestmentId = DatabaseSeeder.Investment1Id;
            const string UserId = "nonExistentUserId";

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var investmentProvider = new InvestmentProvider(dbContext);
                var userInvestmentModel = await investmentProvider.GetUserInvestment(UserId, InvestmentId, CancellationToken.None);

                Assert.Null(userInvestmentModel);
            }
        }

        [Fact]
        public async Task TestGetUserInvestmentLoadsInvestment()
        {
            const int InvestmentId = DatabaseSeeder.Investment1Id;
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var investmentProvider = new InvestmentProvider(dbContext);
                var userInvestmentModel = await investmentProvider.GetUserInvestment(UserId, InvestmentId, CancellationToken.None);

                Assert.NotNull(userInvestmentModel);
                Assert.Equal("TEST_INVEST1", userInvestmentModel.Name);
            }
        }

        [Fact]
        public async Task TestGetUserInvestmentLoadsPurchases()
        {
            const int InvestmentId = DatabaseSeeder.Investment1Id;
            const string UserId = DatabaseSeeder.User1Id;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                var investmentProvider = new InvestmentProvider(dbContext);
                var userInvestmentModel = await investmentProvider.GetUserInvestment(UserId, InvestmentId, CancellationToken.None);

                Assert.NotNull(userInvestmentModel);
                Assert.Equal(2, userInvestmentModel.Purchases.Count());
                Assert.Equal(125, userInvestmentModel.Purchases.Sum(p => p.NumberOfShares));
            }
        }
    }
}
