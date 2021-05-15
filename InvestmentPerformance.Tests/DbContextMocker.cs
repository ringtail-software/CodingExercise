using InvestmentPerformance.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.Tests
{
    public static class DbContextMocker
    {
        public static InvestmentPerformanceDbContext GetInvestmentPerformanceDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<InvestmentPerformanceDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            var dbContext = new InvestmentPerformanceDbContext(options);

            dbContext.Seed();

            return dbContext;
        }
    }
}
