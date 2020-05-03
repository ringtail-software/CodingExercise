using InvestmentAPI.Contexts;
using InvestmentAPI.Models;
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

                if (context.Investments.Any())
                {
                    return;
                }

                if (context.InvestmentDetails.Any())
                {
                    return;
                }

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
                    CostBasisPerShare = 297.31,
                    CurrentPrice = 0,
                    CurrentValue = 0,
                    Term = 0,
                    NetValuation = 0
                };


            }
        }
    }
}
