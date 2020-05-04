using InvestmentAPI.Contexts;
using InvestmentAPI.Models;
using InvestmentAPI.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InvestmentAPI.SeedData
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider service)
        {
            using (var context = new InvestmentContext(
                service.GetRequiredService<DbContextOptions<InvestmentContext>>()))
            {
                Random rand = new Random();

                var inv1 = new Investment()
                {
                    Id = 1,
                    UserId = 100,
                    Name = "APPL",
                    TimeOfPurchase = DateTime.Now
                };

                var inv2 = new Investment()
                {
                    Id = 2,
                    UserId = 100,
                    Name = "TSLA",
                    TimeOfPurchase = DateTime.Now
                };

                var inv3 = new Investment()
                {
                    Id = 3,
                    UserId = 100,
                    Name = "NKE",
                    TimeOfPurchase = DateTime.Now
                };

                var inv1Detail = new InvestmentDetail()
                {
                    SystemId = 100,
                    InvestmentId = 1,
                    Shares = rand.Next(1, 20),
                    CostBasisPerShare = Math.Round(rand.NextDouble() * 500, 2),
                    CurrentPrice = 0,
                    CurrentValue = 0,
                    Term = 0,
                    NetValuation = 0
                };

                var inv2Detail = new InvestmentDetail()
                {
                    SystemId = 101,
                    InvestmentId = 2,
                    Shares = rand.Next(1, 20),
                    CostBasisPerShare = Math.Round(rand.NextDouble() * 500, 2),
                    CurrentPrice = 0,
                    CurrentValue = 0,
                    Term = 0,
                    NetValuation = 0
                };

                var inv3Detail = new InvestmentDetail()
                {
                    SystemId = 102,
                    InvestmentId = 3,
                    Shares = rand.Next(1, 20),
                    CostBasisPerShare = Math.Round(rand.NextDouble() * 500, 2),
                    CurrentPrice = 0,
                    CurrentValue = 0,
                    Term = 1,
                    NetValuation = 0
                };

                inv1Detail.CurrentPrice = InvestmentCalculator.GeneratePrice(inv1Detail.CostBasisPerShare);
                inv1Detail.CurrentValue = InvestmentCalculator.DetermineValue(inv1Detail.Shares, inv1Detail.CurrentPrice);
                inv1Detail.NetValuation = InvestmentCalculator.DetermineNetValuation(inv1Detail.CurrentValue,
                                                                                     inv1Detail.Shares,
                                                                                     inv1Detail.CostBasisPerShare);

                inv2Detail.CurrentPrice = InvestmentCalculator.GeneratePrice(inv2Detail.CostBasisPerShare);
                inv2Detail.CurrentValue = InvestmentCalculator.DetermineValue(inv2Detail.Shares, inv2Detail.CurrentPrice);
                inv2Detail.NetValuation = InvestmentCalculator.DetermineNetValuation(inv2Detail.CurrentValue,
                                                                                     inv2Detail.Shares,
                                                                                     inv2Detail.CostBasisPerShare);

                inv3Detail.CurrentPrice = InvestmentCalculator.GeneratePrice(inv3Detail.CostBasisPerShare);
                inv3Detail.CurrentValue = InvestmentCalculator.DetermineValue(inv3Detail.Shares, inv3Detail.CurrentPrice);
                inv3Detail.NetValuation = InvestmentCalculator.DetermineNetValuation(inv3Detail.CurrentValue,
                                                                                     inv3Detail.Shares,
                                                                                     inv3Detail.CostBasisPerShare);

                context.Investments.Add(inv1);
                context.Investments.Add(inv2);
                context.Investments.Add(inv3);
                context.InvestmentDetails.Add(inv1Detail);
                context.InvestmentDetails.Add(inv2Detail);
                context.InvestmentDetails.Add(inv3Detail);
                context.SaveChanges();
            }
        }
    }
}
