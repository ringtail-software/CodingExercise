using System;
using InvestmentPerformance.Domain.AggregatesModel;
using InvestmentPerformance.Infrastructure.DataSeeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPerformance.Infrastructure.EntityConfigurations
{
    public class InvestmentEntityTypeConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("Investment");

            builder.HasData(InvestmentData.GetInvestmentData());

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id);

            builder.Property(e => e.Name);

            builder.Property(e => e.UserId);

            builder.Property(e => e.DateCreated);
        }
    }
}
