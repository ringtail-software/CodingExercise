using InvestmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentAPI.Contexts
{
    public class InvestmentContext : DbContext
    {
        public InvestmentContext(DbContextOptions<InvestmentContext> options)
            : base(options) { }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentDetail> InvestmentDetails { get; set; }
    }
}
