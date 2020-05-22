namespace TradingApp.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TradingApp.Data.Entities;

    /// <summary>
    /// A repository for managing <see cref="Investment"/> entities.
    /// </summary>
    public class InvestmentRepository : IRepository<Investment>
    {
        /// <inheritdoc />
        public Investment FindById(int id)
        {
            return new Investment
            {
                Id = id,
                Name = "Foo",
                PurchaseDate = DateTime.Now.AddDays(-10),
                PurchasePrice = 25.00m,
                Shares = 100,
                UserId = 10,
            };
        }

        /// <inheritdoc />
        public IQueryable<Investment> GetAll()
        {
            return new List<Investment>
            {
                new Investment
                {
                    Id = 1,
                    Name = "Foo",
                    PurchaseDate = DateTime.Now.AddDays(-10),
                    PurchasePrice = 25.00m,
                    Shares = 100,
                    UserId = 1,
                },

                new Investment
                {
                    Id = 2,
                    Name = "Bar",
                    PurchaseDate = DateTime.Now.AddDays(-100),
                    PurchasePrice = 35.00m,
                    Shares = 50,
                    UserId = 1,
                },

                new Investment
                {
                    Id = 3,
                    Name = "Baz",
                    PurchaseDate = DateTime.Now.AddDays(-1000),
                    PurchasePrice = 18.00m,
                    Shares = 1000,
                    UserId = 2,
                },
            }.AsQueryable();
        }
    }
}
