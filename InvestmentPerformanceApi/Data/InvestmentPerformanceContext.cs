using InvestmentPerformanceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformanceApi.Data
{
    public class InvestmentPerformanceContext : DbContext
    {
        public InvestmentPerformanceContext(DbContextOptions<InvestmentPerformanceContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Investments> Investments { get; set; }

        public DbSet<InvestmentDetails> InvestmentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId)
                .HasName("PrimaryKey_UserId");

            modelBuilder.Entity<Investments>()
                .HasKey(i => new { i.InvestmentId, i.UserId })
                .HasName("PrimaryKey_InvestmentId")
                .HasName("ForeignKey_UserId");

            modelBuilder.Entity<InvestmentDetails>()
                .HasKey(d => new { d.InvestmentId, d.CompanyName })
                .HasName("PrimaryKey_InvestmentId")
                .HasName("ForeignKey_CompanyName");

        }
    }
}

