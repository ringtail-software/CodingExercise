using Investment.API.DbContexts;
using Investment.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investment.API.Seeders
{
    public class DbSeeder
    {
        public static void Initialize(InvestmentContext context, IServiceProvider services)
        {
            var logger = services.GetRequiredService<ILogger<DbSeeder>>();

            context.Database.EnsureCreated();

            logger.LogInformation("Seeding started.");

            context.Securities.Add(new Security()
            {
                Symbol = "GOOG",
                Name = "Alphabet Inc.",
                CurrentPrice = 2482.85M
            });

            context.Securities.Add(new Security()
            {
                Symbol = "MSFT",
                Name = "Microsoft Corporation",
                CurrentPrice = 252.57M
            });

            context.Securities.Add(new Security()
            {
                Symbol = "AAPL",
                Name = "Apple",
                CurrentPrice = 126.74M
            });

            context.Securities.Add(new Security()
            {
                Symbol = "X",
                Name = "U.S. Steel",
                CurrentPrice = 26.41M
            });

            context.Securities.Add(new Security()
            {
                Symbol = "TSLA",
                Name = "Tesla, Inc.",
                CurrentPrice = 603.59M
            });

            context.SaveChanges();

            context.Investments.Add(new Entities.Investment()
            {
                Name = "A",
                PurchaseDate = new DateTime(2020, 10, 08),
                PurchasePrice = 2115.5M,
                Shares = 193.63M,
                Security = context.Securities.First(s => s.Symbol == "GOOG"),
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "B",
                PurchaseDate = new DateTime(2021, 01, 17),
                PurchasePrice = 2815.21M,
                Shares = 33.81M,
                Security = context.Securities.First(s => s.Symbol == "GOOG")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "C",
                PurchaseDate = new DateTime(2009, 2, 1),
                PurchasePrice = 1815.21M,
                Shares = 357.15M,
                Security = context.Securities.First(s => s.Symbol == "GOOG")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "D",
                PurchaseDate = new DateTime(2021, 1, 25),
                PurchasePrice = 342.57M,
                Shares = 5.7M,
                Security = context.Securities.First(s => s.Symbol == "MSFT")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "E",
                PurchaseDate = new DateTime(2018, 12, 14),
                PurchasePrice = 187.57M,
                Shares = 82.17M,
                Security = context.Securities.First(s => s.Symbol == "MSFT")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "F",
                PurchaseDate = new DateTime(2017, 11, 28),
                PurchasePrice = 246.12M,
                Shares = 3.9M,
                Security = context.Securities.First(s => s.Symbol == "MSFT")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "G",
                PurchaseDate = new DateTime(2016, 9, 10),
                PurchasePrice = 92.34M,
                Shares = 89.39M,
                Security = context.Securities.First(s => s.Symbol == "AAPL")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "H",
                PurchaseDate = new DateTime(2015, 8, 9),
                PurchasePrice = 205.34M,
                Shares = 97.02M,
                Security = context.Securities.First(s => s.Symbol == "AAPL")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "I",
                PurchaseDate = new DateTime(2013, 7, 8),
                PurchasePrice = 12.34M,
                Shares = 18.18M,
                Security = context.Securities.First(s => s.Symbol == "AAPL")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "J",
                PurchaseDate = new DateTime(2012, 6, 15),
                PurchasePrice = 92.34M,
                Shares = 24.99M,
                Security = context.Securities.First(s => s.Symbol == "X")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "K",
                PurchaseDate = new DateTime(2021, 5, 11),
                PurchasePrice = 22.97M,
                Shares = 19.47M,
                Security = context.Securities.First(s => s.Symbol == "X")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "L",
                PurchaseDate = new DateTime(2021, 4, 8),
                PurchasePrice = 47.91M,
                Shares = 66.68M,
                Security = context.Securities.First(s => s.Symbol == "X")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "M",
                PurchaseDate = new DateTime(2021, 3, 7),
                PurchasePrice = 531.06M,
                Shares = 27.90M,
                Security = context.Securities.First(s => s.Symbol == "TSLA")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "N",
                PurchaseDate = new DateTime(2021, 2, 5),
                PurchasePrice = 788.77M,
                Shares = 42.13M,
                Security = context.Securities.First(s => s.Symbol == "TSLA")
            });

            context.Investments.Add(new Entities.Investment()
            {
                Name = "O",
                PurchaseDate = new DateTime(2017, 1, 4),
                PurchasePrice = 426.74M,
                Shares = 10.25M,
                Security = context.Securities.First(s => s.Symbol == "TSLA")
            });

            context.SaveChanges();

            context.Users.Add(new User()
            {
                UserName = Guid.Parse("76505fef-a4db-483c-b2bc-51258f97f0fa"),
                FirstName = "George",
                LastName = "Washington",
                Investments = new List<Entities.Investment> { context.Investments.First(i => i.Name == "A"), context.Investments.First(i => i.Name == "B"), context.Investments.First(i => i.Name == "C"), context.Investments.First(i => i.Name == "D"), context.Investments.First(i => i.Name == "E") }
            });

            context.Users.Add(new User()
            {
                UserName = Guid.Parse("83db1e28-edf1-404d-81d9-c5071239a3af"),
                FirstName = "Theodore",
                LastName = "Roosevelt",
                Investments = new List<Entities.Investment> { context.Investments.First(i => i.Name == "F"), context.Investments.First(i => i.Name == "G"), context.Investments.First(i => i.Name == "H"), context.Investments.First(i => i.Name == "I"), context.Investments.First(i => i.Name == "J") }
            });

            context.Users.Add(new User()
            {
                UserName = Guid.Parse("4039a6b7-18dc-4c6f-928e-e4f2c1117ff5"),
                FirstName = "Abraham",
                LastName = "Lincoln",
                Investments = new List<Entities.Investment> { context.Investments.First(i => i.Name == "K"), context.Investments.First(i => i.Name == "L"), context.Investments.First(i => i.Name == "M"), context.Investments.First(i => i.Name == "N"), context.Investments.First(i => i.Name == "O") }
            });

            context.SaveChanges();

            logger.LogInformation("Seeding finished.");

        }
    }
}
