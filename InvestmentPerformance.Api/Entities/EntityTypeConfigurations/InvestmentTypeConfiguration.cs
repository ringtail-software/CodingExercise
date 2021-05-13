using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InvestmentPerformance.Api.Entities.EntityTypeConfigurations
{
    public class InvestmentTypeConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.CurrentPrice)
                .HasPrecision(15, 2);

            builder.HasData(
                new Investment { Id = 1, Name = "INVEST1", CurrentPrice = 35.35m, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
                new Investment { Id = 2, Name = "INVEST2", CurrentPrice = 12.00m, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
                new Investment { Id = 3, Name = "INVEST3", CurrentPrice = 23.5m, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
                new Investment { Id = 4, Name = "INVEST4", CurrentPrice = 19.22m, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow });
        }
    }
}
