using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuixInvestments.Data;
using NuixInvestments.MiddleWare.Data.POCO;
using NuixInvestments.MiddleWare.Data.Repo.Interfaces;
using NuixInvestments.MiddleWare.Data.Repo.Static;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NuixInvestments.Tests
{
    [TestClass]
    public class Middleware_Test
    {
        /// <summary>
        /// Returns a new repo and resets the data to its starting values
        /// </summary>
        /// <returns></returns>
        public IUserRepo CreateStandardTestRepo()
        {
            IUserRepo repo = new StaticUserRepo();
            StaticUserRepo.Investments = new List<Investment>
            {
                new Investment { Id = 1, FullName = "McDonald's Corporation", Abbreviation = "MCD", CurrentPrice = 250.00M,
                    DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-9) },
                new Investment { Id = 2, FullName = "Yum! Brands, Inc.", Abbreviation = "YUM", CurrentPrice = 100.00M,
                    DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-9) },
                new Investment { Id = 3, FullName = "Restaurant Brands Internation, Inc.", Abbreviation = "QSR", CurrentPrice = 50.00M,
                    DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-9) },
                new Investment { Id = 4, FullName = "Gold", Abbreviation = "GOLD", CurrentPrice = 2000.00M,
                    DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-9) },
                new Investment { Id = 5, FullName = "Silver", Abbreviation = "SILV", CurrentPrice = 25.00M,
                    DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-9) },
                new Investment { Id = 6, FullName = "Rhodium", Abbreviation = "RHOD", CurrentPrice = 30000.00M,
                    DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-9) },
                new Investment { Id = 7, FullName = "Microsoft Corporation", Abbreviation = "MSFT", CurrentPrice = 250.00M,
                    DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-9) },
                new Investment { Id = 8, FullName = "Apple Inc", Abbreviation = "AAPL", CurrentPrice = 125.00M,
                    DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-9) },
                new Investment { Id = 9, FullName = "Alphabet Inc Class A", Abbreviation = "GOOGL", CurrentPrice = 2000.00M,
                    DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-9) }
            };

            StaticUserRepo.Users = new List<User>
            {
                new User { Id = 1, DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-1), DateOfBirth = DateTime.Now.AddDays(-10000).Date,
                    FirstName = "Jane", MiddleName = "Jill", LastName = "Stone", UserName = "JJSTONE" },
                new User { Id = 2, DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-1), DateOfBirth = DateTime.Now.AddDays(-12000).Date,
                    FirstName = "Richard", MiddleName = "Steven", LastName = "Masters", UserName = "RSMASTERS" },
                new User { Id = 3, DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-1), DateOfBirth = DateTime.Now.AddDays(-22500).Date,
                    FirstName = "Ian", MiddleName = "Michael", LastName = "Rich", UserName = "IMRICH" },
                new User { Id = 4, DeletedDate = DateTime.Now.AddDays(-1), CreatedDate = DateTime.Now.AddDays(-2), DateOfBirth = DateTime.Now.AddDays(-22500).Date,
                    FirstName = "Norman", MiddleName = "Oswald", LastName = "Access", UserName = "NOACCESS" },
                new User { Id = 5, DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-2), DateOfBirth = DateTime.Now.AddDays(-22500).Date,
                    FirstName = "Nicholas", MiddleName = "Oliver", LastName = "Stocks", UserName = "NOSTOCKS" }
            };

            StaticUserRepo.UserInvestments = new List<UserInvestment>
            {
                new UserInvestment { InvestmentId = 4, UserId = 1, AveragePurchasePrice = 1600.00M,
                    ChangeTimeStamp = DateTime.Now.AddDays(-3), CurrentShares = 50, PriceAtChange = 1600.00M, ShareDifference = 50 },
                new UserInvestment { InvestmentId = 1, UserId = 2, AveragePurchasePrice = 300.00M,
                    ChangeTimeStamp = DateTime.Now.AddDays(-2), CurrentShares = 100, PriceAtChange = 300.00M, ShareDifference = 100 },
                new UserInvestment { InvestmentId = 9, UserId = 3, AveragePurchasePrice = 1000.00M,
                    ChangeTimeStamp = DateTime.Now.AddMonths(-1), CurrentShares = 60000, PriceAtChange = 1000.00M, ShareDifference = 60000 },
                new UserInvestment { InvestmentId = 7, UserId = 3, AveragePurchasePrice = 225.00M,
                    ChangeTimeStamp = DateTime.Now.AddYears(-2), CurrentShares = 50000, PriceAtChange = 225.00M, ShareDifference = 50000 },
                new UserInvestment { InvestmentId = 5, UserId = 3, AveragePurchasePrice = 30.00M,
                    ChangeTimeStamp = DateTime.Now.AddYears(-2), CurrentShares = 0, PriceAtChange = 15.00M, ShareDifference = -50000 },
                new UserInvestment { InvestmentId = 4, UserId = 3, AveragePurchasePrice = 2000.00M,
                    ChangeTimeStamp = DateTime.Now.AddMonths(-11), CurrentShares = 0, PriceAtChange = 1500.00M, ShareDifference = -50000 }

            };

            return repo;
        }

        [TestMethod]
        public void GetAllUserInvestments_AccessDeletedUser_ReturnsNull()
        {
            const int NOACCESS_USERID = 4;

            IUserRepo repo = CreateStandardTestRepo();
            IMiddleWare middleWare = new Data.MiddleWare(repo);
            
            var returnValue = middleWare.GetAllInvestmentsForUser(NOACCESS_USERID);
            Assert.IsNull(returnValue);
        }

        [TestMethod]
        public void GetAllUserInvestments_AccessUserWithNoPortfolio_ReturnsEmptyCollection()
        {
            const int NOSTOCKS_USERID = 5;

            IUserRepo repo = CreateStandardTestRepo();
            IMiddleWare middleWare = new Data.MiddleWare(repo);

            var returnValue = middleWare.GetAllInvestmentsForUser(NOSTOCKS_USERID)?.ToList();
            Assert.IsNotNull(returnValue);
            Assert.AreEqual(returnValue.Count, 0);
        }

        [TestMethod]
        public void GetAllUserInvestments_AccessUserWithPortfolio_ReturnsCollectionIncludingRecentlyDumpedStocks()
        {
            const int IMRICH_USERID = 3;

            IUserRepo repo = CreateStandardTestRepo();
            var returnValue = repo.GetAllInvestmentsByUser(IMRICH_USERID)?.ToList();
            Assert.IsNotNull(returnValue);

            // there are 4 total stocks, but silver was dumped over a year ago so it should be 3
            Assert.AreEqual(returnValue.Count, 3);
        }
    }
}
