using Microsoft.EntityFrameworkCore;
using InvestmentPerformance.Api.Entities.EntityTypeConfigurations;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

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
            SetBaseEntityProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseEntityProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetBaseEntityProperties();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetBaseEntityProperties()
        {
            var baseEntityEntries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in baseEntityEntries)
            {
                ((BaseEntity)entry.Entity).UpdatedDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedDate = DateTime.UtcNow;
                }
            }
        }
    }
}
