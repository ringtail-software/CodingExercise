using NuixInvestments.MiddleWare.Data.POCO;
using NuixInvestments.MiddleWare.Data.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NuixInvestments.MiddleWare.Data.Repo.Static
{
    public class StaticUserRepo : IUserRepo
    {
        public static List<Investment> Investments = new List<Investment>
        {
            new Investment { Id = 1, FullName = "McDonald's Corporation", Abbreviation = "MCD", CurrentPrice = 250.00M },
            new Investment { Id = 2, FullName = "Yum! Brands, Inc.", Abbreviation = "YUM", CurrentPrice = 100.00M },
            new Investment { Id = 3, FullName = "Restaurant Brands Internation, Inc.", Abbreviation = "QSR", CurrentPrice = 50.00M },
            new Investment { Id = 101, FullName = "Gold", Abbreviation = "GOLD", CurrentPrice = 2000.00M },
            new Investment { Id = 103, FullName = "Silver", Abbreviation = "SILV", CurrentPrice = 25.00M },
            new Investment { Id = 105, FullName = "Rhodium", Abbreviation = "RHOD", CurrentPrice = 30000.00M },
            new Investment { Id = 1001, FullName = "Microsoft Corporation", Abbreviation = "MSFT", CurrentPrice = 250.00M },
            new Investment { Id = 1007, FullName = "Apple Inc", Abbreviation = "AAPL", CurrentPrice = 125.00M },
            new Investment { Id = 1466, FullName = "Alphabet Inc Class A", Abbreviation = "GOOGL", CurrentPrice = 2000.00M }
        };

        public static List<User> Users = new List<User>
        {
            new User { Id = 1, DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-1), DateOfBirth = DateTime.Now.AddDays(-10000).Date,
                FirstName = "Jane", MiddleName = "Jill", LastName = "Stone", UserName = "JJSTONE" },
            new User { Id = 2, DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-1), DateOfBirth = DateTime.Now.AddDays(-12000).Date,
                FirstName = "Richard", MiddleName = "Steven", LastName = "Masters", UserName = "RSMASTERS" },
            new User { Id = 3, DeletedDate = null, CreatedDate = DateTime.Now.AddDays(-1), DateOfBirth = DateTime.Now.AddDays(-22500).Date,
                FirstName = "Ian", MiddleName = "Michael", LastName = "Rich", UserName = "IMRICH" },
            new User { Id = 4, DeletedDate = DateTime.Now.AddDays(-1), CreatedDate = DateTime.Now.AddDays(-2), DateOfBirth = DateTime.Now.AddDays(-22500).Date,
                FirstName = "Norman", MiddleName = "Oswald", LastName = "Access", UserName = "NOACCESS" },
        };

        public static List<UserInvestment> PortfolioInvestments = new List<UserInvestment>
        {
            new UserInvestment { InvestmentId = 101, UserId = 1, AveragePurchasePrice = 1600.00M,
                ChangeTimeStamp = DateTime.Now.AddDays(-3), CurrentShares = 50, PriceAtChange = 1600.00M, ShareDifference = 50 },
            new UserInvestment { InvestmentId = 1, UserId = 2, AveragePurchasePrice = 300.00M,
                ChangeTimeStamp = DateTime.Now.AddDays(-2), CurrentShares = 100, PriceAtChange = 300.00M, ShareDifference = 100 },
            new UserInvestment { InvestmentId = 1466, UserId = 3, AveragePurchasePrice = 1000.00M,
                ChangeTimeStamp = DateTime.Now.AddYears(-1), CurrentShares = 60000, PriceAtChange = 1000.00M, ShareDifference = 60000 },
        };

        /// <summary>
        /// Returns UserInvestment entries that have a positive number of shares 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInvestment GetSingleInvestmentsByUser(int userId, int investmentId)
        {
            var user = (from u in Users where u.Id == userId select u).FirstOrDefault();

            if (user == null)
            { 
                return null;
            }
            else
            {
                var investment = (from i in PortfolioInvestments where i.UserId == user.Id 
                                   && i.CurrentShares > 0 && i.InvestmentId == investmentId select i).FirstOrDefault();
                investment.User = user;
                investment.Investment = (from n in Investments where n.Id == investment.InvestmentId select n).First();
                return investment;
            }
        }

        /// <summary>
        /// Returns UserInvestments that have or had any shares in the past year.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<UserInvestment> GetAllInvestmentsByUser(int userId)
        {
            var user = (from u in Users where u.Id == userId select u).FirstOrDefault();

            if (user == null)
            {
                return null;
            }
            else
            {
                var investments = (from i in PortfolioInvestments where i.UserId == user.Id && 
                                   (i.CurrentShares > 0 || i.ChangeTimeStamp.AddYears(1).Date >= DateTime.Now.Date) select i);
                foreach (var i in investments)
                {
                    i.User = user;
                    i.Investment = (from n in Investments where n.Id == i.InvestmentId select n).First();
                }
                return investments;
            }
        }
    }
}
