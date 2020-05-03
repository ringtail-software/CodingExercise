using InvestmentAPI.Contexts;
using InvestmentAPI.Models;
using InvestmentAPI.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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

                /*if (context.Investments.Any())
                {
                    return;
                }

                if (context.InvestmentDetails.Any())
                {
                    return;
                }*/

                var inv1 = new Investment()
                {
                    Id = 1,
                    UserId = 100,
                    Name = "APPL",
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

                inv1Detail.CurrentPrice = InvestmentCalculator.GeneratePrice(inv1Detail.CostBasisPerShare);
                inv1Detail.CurrentValue = InvestmentCalculator.DetermineValue(inv1Detail.Shares, inv1Detail.CurrentPrice);
                inv1Detail.NetValuation = InvestmentCalculator.DetermineNetValuation(inv1Detail.CurrentValue,
                                                                                     inv1Detail.Shares,
                                                                                     inv1Detail.CostBasisPerShare);

                context.Investments.Add(inv1);
                context.InvestmentDetails.Add(inv1Detail);
                context.SaveChanges();
            }
        }
    }
}
