using System;
using InvestmentPerformance.Infrastructure;
using InvestmentPerformance.Infrastructure.DataSeeding;
using InvestmentPerformance.Tests.Helpers;

namespace InvestmentPerformance.Tests.MockData
{
    public class InvestmentMockData
    {
        public static InvestmentPerformanceContext GetContext()
        {
            var context = InMemoryDatabaseHelper.GetInMemoryContext();

            var mockData = InvestmentDataSeeding.GetData();

            context.Investments.AddRange(mockData);
            context.SaveChanges();

            return context;
        }

        public static InvestmentPerformanceContext GetEmptyContext()
        {
            return InMemoryDatabaseHelper.GetInMemoryContext();
        }
    }
}
