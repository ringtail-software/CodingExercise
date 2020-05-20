using InvestmentPerformance.Data.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace InvestmentPerformance.Tests
{
    public class InMemoryDb : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly DbContextOptions<InvestmentDbContext> _options;

        public InMemoryDb()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            _options = new DbContextOptionsBuilder<InvestmentDbContext>()
                .UseSqlite(_connection)
                .Options;

            using (var context = new InvestmentDbContext(_options))
            {
                context.Database.EnsureCreated();
            }
        }

        public InvestmentDbContext Create() => new InvestmentDbContext(_options);
        public void Dispose() => _connection.Dispose();
    }
}
