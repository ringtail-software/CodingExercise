using System;
using System.Data.Common;
using InvestmentPerformance.Api.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace InvestmentPerformance.Tests
{
    public class DbContextTestBase : IDisposable
    {
        private readonly DbConnection _connection;

        protected DbContextOptions<InvestmentPerformanceDbContext> ContextOptions { get; }

        public DbContextTestBase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            ContextOptions = new DbContextOptionsBuilder<InvestmentPerformanceDbContext>()
                .UseSqlite(connection)
                .Options;

            _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;

            using (var dbContext = new InvestmentPerformanceDbContext(ContextOptions))
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                DatabaseSeeder.Seed(dbContext);
            }
        }

        public void Dispose() => _connection.Dispose();
    }
}