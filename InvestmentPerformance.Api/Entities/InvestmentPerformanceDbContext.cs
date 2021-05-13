using Microsoft.EntityFrameworkCore;
using InvestmentPerformance.Api.Entities.EntityTypeConfigurations;
using System;
using System.Linq;

namespace InvestmentPerformance.Api.Entities
{
    public class InvestmentPerformanceDbContext : DbContext
    {
        public InvestmentPerformanceDbContext(DbContextOptions<InvestmentPerformanceDbContext> options)
            : base(options) { }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<UserInvestment> UserInvestments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvestmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserInvestmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((BaseEntity)entry.Entity).UpdatedDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedDate = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
