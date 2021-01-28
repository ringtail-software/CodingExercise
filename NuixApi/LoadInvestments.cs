using System;
using System.Linq;
using NuixApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace NuixApi
{
    public static class LoadInvestments
    {
        /*This class will load a sample set of data into the in memory database.*/

        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Get the database context
            using (var context = new NuixContext(serviceProvider.GetRequiredService<DbContextOptions<NuixContext>>()))
            {
                if (context.Investments.Any())
                {
                    return;
                }

                context.Investments.Add(
                    new Investment
                    {
                        Id = 1,
                        InvestmentName = "PNC"
                    });
                context.Investments.Add(
                  new Investment
                  {
                      Id = 2,
                      InvestmentName = "Google"
                  });
                context.Investments.Add(
                  new Investment
                  {
                      Id = 3,
                      InvestmentName = "Microsoft"
                  });
                context.Investments.Add(
                  new Investment
                  {
                      Id = 4,
                      InvestmentName = "Apple"
                  });
                context.Investments.Add(
                  new Investment
                  {
                      Id = 5,
                      InvestmentName = "Peleton"
                  });

                context.InvestmentDetails.Add(
                    new InvestmentDetails
                    {
                        Id = 1,
                        PriceWhenPurchased = 125.75,
                        CurrentPrice = 137.43,
                        DatePurchased = Convert.ToDateTime("5/15/2019"),
                        NumberOfSharesOwned = 500
                    });
                context.InvestmentDetails.Add(new InvestmentDetails
                {
                    Id = 2,
                    PriceWhenPurchased = 2500,
                    CurrentPrice = 2365,
                    DatePurchased = Convert.ToDateTime("1/31/2020"),
                    NumberOfSharesOwned = 25
                });
                context.InvestmentDetails.Add(new InvestmentDetails
                {
                    Id = 3,
                    PriceWhenPurchased = 232.90,
                    CurrentPrice = 232.50,
                    DatePurchased = Convert.ToDateTime("1/27/2021"),
                    NumberOfSharesOwned = 250
                });
                context.InvestmentDetails.Add(new InvestmentDetails
                {
                    Id = 4,
                    PriceWhenPurchased = 38.74,
                    CurrentPrice = 137.43,
                    DatePurchased = Convert.ToDateTime("5/25/2017"),
                    NumberOfSharesOwned = 100
                });
                context.InvestmentDetails.Add(new InvestmentDetails
                {
                    Id =5,
                    PriceWhenPurchased = 140.69,
                    CurrentPrice = 143.50,
                    DatePurchased = Convert.ToDateTime("1/27/2021"),
                    NumberOfSharesOwned = 750
                });
                context.SaveChanges();
            }
        }
    }
}
