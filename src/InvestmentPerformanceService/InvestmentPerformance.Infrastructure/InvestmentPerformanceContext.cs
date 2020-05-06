using System;
using InvestmentPerformance.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.Infrastructure
{
    public class InvestmentPerformanceContext : DbContext
    {
        public InvestmentPerformanceContext(DbContextOptions<InvestmentPerformanceContext> options)
                    : base(options)
        {
        }

        public DbSet<Investment> Investments { get; set; }
    }
}
