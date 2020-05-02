using InvestmentAPI.Contexts;
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
                if (context.Investments.Any())
                {
                    return;
                }

                if (context.InvestmentDetails.Any())
                {
                    return;
                }

                
            }
        }
    }
}
