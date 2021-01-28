 using Microsoft.EntityFrameworkCore;
namespace NuixApi.Models
{
    public class NuixContext:DbContext
    {
        public NuixContext(DbContextOptions<NuixContext> options):base(options)
        {

        }

        public DbSet<Investment> Investments { get; set; }

        public DbSet<InvestmentDetails> InvestmentDetails { get; set; }
    }
}
