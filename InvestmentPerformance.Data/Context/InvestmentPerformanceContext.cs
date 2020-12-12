using InvestmentPerformance.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.Data.Context
{
    public class InvestmentPerformanceContext : DbContext
    {
        private readonly string _connectionString;

        public InvestmentPerformanceContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public InvestmentPerformanceContext(DbContextOptions<InvestmentPerformanceContext> dbOptions)
            : base(dbOptions) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInvestment> UserInvestments { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
