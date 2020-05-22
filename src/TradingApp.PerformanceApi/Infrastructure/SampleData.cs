namespace TradingApp.PerformanceApi.Infrastructure
{
    using System;
    using Bogus;
    using Microsoft.Extensions.DependencyInjection;
    using TradingApp.Data;
    using TradingApp.Data.Entities;

    /// <summary>
    /// Sample trading app data.
    /// </summary>
    public static class SampleData
    {
        /// <summary>
        /// Seed the trading app database with sample data.
        /// </summary>
        /// <param name="services">The service locator.</param>
        public static void SeedDb(IServiceProvider services)
        {
            using var db = services.GetRequiredService<TradingAppContext>();

            var investmentFaker = new Faker<Investment>()
                .Ignore(p => p.Id)
                .Ignore(p => p.UserId)
                .RuleFor(p => p.Name, f => f.Company.CompanyName())
                .RuleFor(p => p.PurchaseDate, f => DateTime.Now.AddDays(f.Random.Int(0, 15000) * -1))
                .RuleFor(p => p.PurchasePrice, f => f.Finance.Amount())
                .RuleFor(p => p.Shares, f => f.Random.Int(1, 500));

            var investmentId = 1;
            var faker = new Faker();

            // seed 5 users
            for (var userId = 1; userId <= 5; userId++)
            {
                // seed a 1 to 20 stocks per user
                var numStocks = new Faker().Random.Int(1, 20);
                for (var j = 0; j < numStocks; j++)
                {
                    var investment = investmentFaker.Generate();

                    investment.Id = investmentId++;
                    investment.UserId = userId;

                    db.Investments.Add(investment);
                }
            }

            db.SaveChanges();
        }
    }
}
