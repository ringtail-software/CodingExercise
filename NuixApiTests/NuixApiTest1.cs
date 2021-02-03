using NUnit.Framework;
using NuixApi.Models;
using NuixApi.Controllers;
using NuixApi.DatabaseCalls;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace NuixApiTests
{

    public class NuixApiTest1
    {
        //[SetUp]
        //public void Setup()
        //{

        //}
        [Test]
        public async Task TestReturnAllInvestments()
        {
            InvestmentsController investmentsController = new InvestmentsController(LoadSampleDatabaseAndReturnContext());
            var result = await investmentsController.GetInvestments();

            //The result should be json and not null;
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task TestReturnSpecificInvestment()
        {
            //Get the investment details about Peleton

            InvestmentsController investmentsController = new InvestmentsController(LoadSampleDatabaseAndReturnContext());
            var result = await investmentsController.GetInvestmentDetails(5);

            //The result should be json and not null;
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task TestDatabaseCallAsync()
        {
            //Set up the correct results to match open what we should get.

            var id = 1;
            var investmentName = "PNC";
            var numberOfShares = 500;
            var costBasisPerShare = 125.75; //Price we paid per share when we bought the stock
            var currentPrice = 137.43;
            var currentValue = 68715; //Number of shares * current price
            var shortOrLongTerm = "Long Term"; //Should be long term since it over 1 year
            var gainOrLoss = 5840; //currentValue - (number of shares * costBasisPerShare)

            //Load the sample database and return the context
            //Get the results back from the database call
            InvestmentOutput result = await InvestmentDatabaseCalls.GetInvestmentDetails(LoadSampleDatabaseAndReturnContext(), id);
            Assert.AreEqual(result.Id, id);
            Assert.AreEqual(result.Name, investmentName);
            Assert.AreEqual(result.NumberOfShares, numberOfShares);
            Assert.AreEqual(result.CostBasisPerShare, costBasisPerShare);
            Assert.AreEqual(result.CurrentPrice, currentPrice);
            Assert.AreEqual(result.CurrentValue, currentValue);
            Assert.AreEqual(result.Term, shortOrLongTerm);
            Assert.AreEqual(result.GainOrLoss, gainOrLoss);

        }
        private NuixContext LoadSampleDatabaseAndReturnContext()
        {
            var options = new DbContextOptionsBuilder<NuixContext>()
         .UseInMemoryDatabase(databaseName: "InvestmentDatabase")
         .Options;

            // Get the database context
            var context = new NuixContext(options);

            if (context.Investments.Any())
            {
                return context;
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
                Id = 5,
                PriceWhenPurchased = 140.69,
                CurrentPrice = 143.50,
                DatePurchased = Convert.ToDateTime("1/27/2021"),
                NumberOfSharesOwned = 750
            });
            context.SaveChanges();

            return context;
        }
    }
}

