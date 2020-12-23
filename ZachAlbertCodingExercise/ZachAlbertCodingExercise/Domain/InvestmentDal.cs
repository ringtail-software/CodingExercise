using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ZachAlbertCodingExercise.Models;

namespace ZachAlbertCodingExercise.Domain
{
    public class InvestmentDal
    {
        private readonly InvestmentContext _database;


        //pass in IAutoMapper to convert database entity to code object
        public InvestmentDal(DbContext context)
        {
            _database = (InvestmentContext)context;

            if(_database.User == null || !_database.User.Any())
                PopulateInvestmentData();
        }

        public virtual async Task<List<UserInvestment>> RetrieveUserInvestments(int userId)
        {
            var investments = await _database.Investments.AsNoTracking()
                .Where(p => p.UserId == userId)
                .Join(_database.Stock.AsNoTracking(), p => p.StockId, p2 => p2.StockId,
                    (p, pq2) => new UserInvestment
                    {
                        InvestmentId = p.Id,
                        StockId = p.StockId,
                        StockName = pq2.StockName,
                        CurrentStockPrice = pq2.CurrentPrice
                    })
                .ToListAsync();
            return investments;
        }

        public virtual async Task<List<UserInvestment>> RetrieveUserInvestments(int userId, int investmentId)
        {
            var investments = await _database.Investments.AsNoTracking()
                .Where(p => p.UserId == userId)
                .Where(p => p.StockId == investmentId)
                .Join(_database.Stock.AsNoTracking(), p => p.StockId, p2 => p2.StockId,
                    (p, pq2) => new UserInvestment
                    {
                        InvestmentId = p.Id,
                        StockId = p.StockId,
                        StockName = pq2.StockName,
                        CurrentStockPrice = pq2.CurrentPrice,
                        PurchasePrice = p.PurchasePrice,
                        PurchaseAmount = p.PurchaseAmount,
                        PurchaseDate = p.PurchaseDate
                    })
                .ToListAsync();
            return investments;
        }


        public void PopulateInvestmentData()
        {
            //_database.User = new DbSet<User>();
            _database.User.Add(new User {UserId = 1, Name = "Zach Albert"});
            _database.User.Add(new User {UserId = 2, Name = "Zach Albert 1"});

            _database.Stock.Add(new Stock {StockId = 1, StockName = "Stock1", CurrentPrice = 10});
            _database.Stock.Add(new Stock { StockId = 2, StockName = "Stock2", CurrentPrice = 20 });
            _database.Stock.Add(new Stock { StockId = 3, StockName = "Stock3", CurrentPrice = 30 });

            _database.Investments.Add(new Investments {Id = 1, UserId = 1, StockId = 1, PurchaseAmount = 10, PurchasePrice = 10, PurchaseDate = new DateTime(2020, 12, 1) });
            _database.Investments.Add(new Investments { Id = 2, UserId = 1, StockId = 2, PurchaseAmount = 10, PurchasePrice = 10, PurchaseDate = new DateTime(2019, 12, 1) });
            _database.Investments.Add(new Investments { Id = 3, UserId = 1, StockId = 3, PurchaseAmount = 10, PurchasePrice = 40, PurchaseDate = new DateTime(2020, 12, 1) });
            _database.Investments.Add(new Investments { Id = 4, UserId = 2, StockId = 1, PurchaseAmount = 100, PurchasePrice = 1, PurchaseDate = new DateTime(2018, 12, 1) });

        }
        

    }
}