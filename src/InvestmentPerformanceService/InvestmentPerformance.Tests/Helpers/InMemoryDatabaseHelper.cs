using System;
using InvestmentPerformance.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.Tests.Helpers
{
    public class InMemoryDatabaseHelper
    {
        public static InvestmentPerformanceContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<InvestmentPerformanceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new InvestmentPerformanceContext(options);
        }
    }
}
