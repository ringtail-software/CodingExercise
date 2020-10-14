using InvestmentPerformance.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace InvestmentPerformance.WebApi.Tests
{
    [Ignore]
    [TestClass]
    public class InvestmentPerformanceContextTests
    {
        private IConfiguration _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private InvestmentPerformanceContext _context;
        private DbContextOptionsBuilder<InvestmentPerformanceContext> _builder = new DbContextOptionsBuilder<InvestmentPerformanceContext>();

        public InvestmentPerformanceContextTests()
        {
            var connectionString = _config.GetConnectionString("InvestmentPerformanceDatabase");
            _builder.UseSqlServer(connectionString);
            _context = new InvestmentPerformanceContext(_builder.Options);
        }

        [TestMethod]
        public async Task Users()
        {
            var users = await _context.Users.Include(u => u.Investments).ThenInclude(ui => ui.Investment).ToListAsync();
        }

        [TestMethod]
        public async Task UserInvestments()
        {
            var userInvestments = await _context.UserInvestments.Include(ui => ui.Investment).ToListAsync();
        }
    }
}
