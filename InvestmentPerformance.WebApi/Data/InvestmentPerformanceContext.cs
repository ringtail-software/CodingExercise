using InvestmentPerformance.WebApi.Data.Entities;
using InvestmentPerformance.WebApi.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.WebApi.Data
{
    public class InvestmentPerformanceContext : DbContext
    {
        public InvestmentPerformanceContext(DbContextOptions<InvestmentPerformanceContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserInvestment> UserInvestments {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvestmentMap());
            modelBuilder.ApplyConfiguration(new UserInvestmentMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
