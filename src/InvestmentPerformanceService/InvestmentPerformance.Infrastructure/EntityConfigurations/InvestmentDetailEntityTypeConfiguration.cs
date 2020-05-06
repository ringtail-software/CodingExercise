using System;
using InvestmentPerformance.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPerformance.Infrastructure.EntityConfigurations
{
    public class InvestmentDetailEntityTypeConfiguration : IEntityTypeConfiguration<InvestmentDetail>
    {
        public void Configure(EntityTypeBuilder<InvestmentDetail> builder)
        {
            builder.ToTable("InvestmentDetail");

            builder.HasData()

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id);

            builder.Property(e => e.InvestmentId);

            builder.Property(e => e.CostBasisPerShare);

            builder.Property(e => e.CurrentPrice);

            builder.Property(e => e.CurrentValue);

            builder.Property(e => e.Term);

            builder.Property(e => e.TotalGainOrLoss);
        }
    }
}
