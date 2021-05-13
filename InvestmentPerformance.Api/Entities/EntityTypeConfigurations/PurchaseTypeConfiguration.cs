using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InvestmentPerformance.Api.Entities.EntityTypeConfigurations
{
    public class PurchaseTypeConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.Property(x => x.CostBasisPerShare)
                .HasPrecision(15, 2);

            builder.HasData(
                new Purchase { Id = 1, UserInvestmentId = 1, CostBasisPerShare = 30.42m, NumberOfShares = 25, CreatedDate = new DateTime(2020, 2, 13), UpdatedDate = new DateTime(2020, 2, 13) },
                new Purchase { Id = 2, UserInvestmentId = 1, CostBasisPerShare = 33.22m, NumberOfShares = 100, CreatedDate = new DateTime(2020, 5, 4), UpdatedDate = new DateTime(2020, 5, 4) },

                new Purchase { Id = 3, UserInvestmentId = 2, CostBasisPerShare = 19.23m, NumberOfShares = 35, CreatedDate = new DateTime(2021, 1, 8), UpdatedDate = new DateTime(2021, 1, 8) },
                new Purchase { Id = 4, UserInvestmentId = 2, CostBasisPerShare = 12.75m, NumberOfShares = 200, CreatedDate = new DateTime(2021, 2, 16), UpdatedDate = new DateTime(2021, 2, 16) },
                new Purchase { Id = 5, UserInvestmentId = 2, CostBasisPerShare = 30.2m, NumberOfShares = 15, CreatedDate = new DateTime(2021, 4, 4), UpdatedDate = new DateTime(2021, 4, 4) },

                new Purchase { Id = 6, UserInvestmentId = 3, CostBasisPerShare = 10.98m, NumberOfShares = 55, CreatedDate = new DateTime(2020, 5, 10), UpdatedDate = new DateTime(2020, 5, 10) },
                
                new Purchase { Id = 7, UserInvestmentId = 4, CostBasisPerShare = 31.00m, NumberOfShares = 45, CreatedDate = new DateTime(2021, 2, 1), UpdatedDate = new DateTime(2021, 2, 1) });
        }
    }
}
