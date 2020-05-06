using InvestmentPerformance.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPerformance.Infrastructure.EntityConfigurations
{
    public class InvestmentEntityTypeConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("Investment");

            builder.HasKey(e => e.Id);

            builder.Ignore(e => e.TermLength);

            builder.Property(e => e.Id).IsRequired();

            builder.Property(e => e.Name).IsRequired();

            builder.Property(e => e.UserId).IsRequired();

            builder.Property(e => e.CostBasisPerShare).IsRequired();

            builder.Property(e => e.CurrentPrice).IsRequired();

            builder.Property(e => e.CurrentValue).IsRequired();

            builder.Property(e => e.Term).IsRequired();

            builder.Property(e => e.TotalGainOrLoss).IsRequired();
        }
    }
}
