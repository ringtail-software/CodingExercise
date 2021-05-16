using InvestmentPerformance.Api.Entities;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestment;
using InvestmentPerformance.Api.RequestHandlers.Investments.GetInvestmentList;
using InvestmentPerformance.Api.Services;
using InvestmentPerformance.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InvestmentPerformance.Tests
{
    public class InvestmentRequestHandlerTests : DbContextTestBase
    {
        [Fact]
        public async Task GetInvestmentRequestHandlerValidTest()
        {
            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                const int InvestmentId = DatabaseSeeder.Investment1Id;
                const string UserId = DatabaseSeeder.User1Id;

                var mockUserProvider = new Mock<ICurrentUserProvider>();
                mockUserProvider.Setup(x => x.GetCurrentUserId()).Returns(UserId);

                var mockLogger = new Mock<ILogger<GetInvestmentRequestHandler>>();

                var request = new GetInvestmentRequest(InvestmentId);

                var investmentProvider = new InvestmentProvider(dbContext);

                var handler = new GetInvestmentRequestHandler(mockUserProvider.Object, mockLogger.Object, investmentProvider);

                var result = await handler.Handle(request, CancellationToken.None);

                Assert.NotNull(result.Value);
            }
        }

        [Fact]
        public async Task GetInvestmentRequestHandlerNotFoundTest()
        {
            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                const int InvestmentId = 5020; // doesn't exist
                const string UserId = DatabaseSeeder.User1Id;

                var mockUserProvider = new Mock<ICurrentUserProvider>();
                mockUserProvider.Setup(x => x.GetCurrentUserId()).Returns(UserId);

                var mockLogger = new Mock<ILogger<GetInvestmentRequestHandler>>();

                var request = new GetInvestmentRequest(InvestmentId);

                var investmentProvider = new InvestmentProvider(dbContext);

                var handler = new GetInvestmentRequestHandler(mockUserProvider.Object, mockLogger.Object, investmentProvider);

                var result = await handler.Handle(request, CancellationToken.None);

                Assert.IsType<NotFoundResult>(result.Result);
            }
        }

        [Fact]
        public async Task GetInvestmentListRequestHandlerTest()
        {
            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                const string UserId = DatabaseSeeder.User1Id;

                var mockUserProvider = new Mock<ICurrentUserProvider>();
                mockUserProvider.Setup(x => x.GetCurrentUserId()).Returns(UserId);

                var request = new GetInvestmentListRequest();

                var investmentProvider = new InvestmentProvider(dbContext);

                var handler = new GetInvestmentListRequestHandler(mockUserProvider.Object, investmentProvider);

                var result = await handler.Handle(request, CancellationToken.None);

                Assert.Equal(2, result.Value.Count());
            }
        }
    }
}
