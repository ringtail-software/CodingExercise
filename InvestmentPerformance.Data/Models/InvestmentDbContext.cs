using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentPerformance.Data.Models
{
    public class InvestmentDbContext : DbContext
    {
        public InvestmentDbContext(DbContextOptions<InvestmentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Remove this if we want a database without seeddata
            #region SeedDataUsedForTesting

            //Users
            var jordanBelfortId = Guid.NewGuid();
            var warrenBuffetId = Guid.NewGuid();
            var joelGramlingId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
                {Id = jordanBelfortId, UserName="Jordan_Belfort" }
            );
            modelBuilder.Entity<User>().HasData(new User
                { Id = warrenBuffetId, UserName = "Warren_Buffet" }
            );
            modelBuilder.Entity<User>().HasData(new User
                { Id = joelGramlingId, UserName = "Joel_Gramling" }
            );

            //Stocks
            var appleStockId = Guid.NewGuid();
            var googleStockId = Guid.NewGuid();
            var microsoftStockId = Guid.NewGuid();
            modelBuilder.Entity<Stock>().HasData(new Stock
                { Id = appleStockId, TickerSymbol = "AAPL", CurrentPrice = 420.69m }
            );
            modelBuilder.Entity<Stock>().HasData(new Stock
                { Id = googleStockId, TickerSymbol = "GOOGL", CurrentPrice = 1010.49m }
            );
            modelBuilder.Entity<Stock>().HasData(new Stock
                { Id = microsoftStockId, TickerSymbol = "MSFT", CurrentPrice = 200.20m }
            );

            //Investments
            modelBuilder.Entity<Investment>().HasData(new Investment
                { Id = Guid.NewGuid(), UserId = jordanBelfortId, StockId = appleStockId, IsBuy = true, Price = 313.14m, Shares=200, EventTime = DateTime.UtcNow.AddDays(-1)}
            );
            modelBuilder.Entity<Investment>().HasData(new Investment
                { Id = Guid.NewGuid(), UserId = jordanBelfortId, StockId = appleStockId, IsBuy = false, Price = 400.20m, Shares = 100, EventTime = DateTime.UtcNow }
            );
            modelBuilder.Entity<Investment>().HasData(new Investment
                { Id = Guid.NewGuid(), UserId = jordanBelfortId, StockId = microsoftStockId, IsBuy = true, Price = 183.63m, Shares = 400, EventTime = DateTime.UtcNow }
            );

            modelBuilder.Entity<Investment>().HasData(new Investment
                { Id = Guid.NewGuid(), UserId = warrenBuffetId, StockId = appleStockId, IsBuy = true, Price = 313.14m, Shares = 200, EventTime = DateTime.UtcNow.AddDays(-1) }
            );
            modelBuilder.Entity<Investment>().HasData(new Investment
                { Id = Guid.NewGuid(), UserId = warrenBuffetId, StockId = appleStockId, IsBuy = true, Price = 400.20m, Shares = 100, EventTime = DateTime.UtcNow }
            );
            modelBuilder.Entity<Investment>().HasData(new Investment
                { Id = Guid.NewGuid(), UserId = warrenBuffetId, StockId = microsoftStockId, IsBuy = true, Price = 183.63m, Shares = 400, EventTime = DateTime.UtcNow }
            );

            modelBuilder.Entity<Investment>().HasData(new Investment
                { Id = Guid.NewGuid(), UserId = joelGramlingId, StockId = googleStockId, IsBuy = true, Price = 1374.40m, Shares = 0.4f, EventTime = DateTime.UtcNow }
           );
        }
        #endregion



        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Investment> Investments { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<Investment> Investments { get; set;  } = new List<Investment>();
    }

    public class Stock
    {
        public Guid Id { get; set; }
        public string TickerSymbol { get; set; }
        //Not 3NF and should be pulled from an api instead, but this is a POC
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentPrice { get; set; }
        public List<Investment> Investments { get; set; } = new List<Investment>();
        public static void Mapping(EntityTypeBuilder<Stock> x)
        {
            x.HasIndex(n => n.TickerSymbol)
                .IsUnique();
        }

    }

    public class Investment
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(StockId))]
        public Stock Stock { get; set; }
        public Guid StockId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public float Shares { get; set; }
        public bool IsBuy { get; set; }
        public DateTime EventTime { get; set; }
    }
}
