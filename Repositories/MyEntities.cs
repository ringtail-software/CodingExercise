using System;
using System.Collections.Generic;
using System.Linq;
using KrummertNuix.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace KrummertNuix.Repositories
{
    public class MyEntities : DbContext
    {
        public MyEntities() { 
            if(this.Portfolios.Count() == 0) {
                AddNewItem();
            }  
        }
        public MyEntities(DbContextOptions<MyEntities> options) : base(options) {  
            if(this.Portfolios.Count() == 0) {
                AddNewItem();
            }
        }
    
        public DbSet<StocksAtPurchase> StocksAtPurchase { get; set; }
        public DbSet<StocksAtCurrent> StocksAtCurrent { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<MyUser> MyUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        private void AddNewItem()
        {
            var stockAtPurchaseId = Guid.NewGuid();
            var stockAtCurrentId = Guid.NewGuid();

            this.Portfolios.Add(
                new Portfolio() {
                    Id = Guid.Parse("aaaaaaaa-40a3-4b1d-a7ee-fdee858ac4c6"),
                    MyUserId = Guid.Parse("c60156c5-40a3-4b1d-a7ee-fdee858ac4c6"),
                    Name = "First Portfolio",
                    StocksAtPurchaseId = stockAtPurchaseId,

                    StocksAtPurchase = new StocksAtPurchase() {
                        Id = stockAtPurchaseId,
                        StocksAtCurrentId = stockAtCurrentId,
                        PricePerShare = 32.56,
                        QtySharesPurchased = 1000,
                        DatePurchased = DateTime.Now.AddYears(-1),

                        StocksAtCurrent = new StocksAtCurrent() {
                            Id = stockAtCurrentId,
                            PricePerShare = 42.53,
                            Name = "Microsoft"
                        }
                    }
                }
            );
            this.SaveChanges();  
        }
    }
} 