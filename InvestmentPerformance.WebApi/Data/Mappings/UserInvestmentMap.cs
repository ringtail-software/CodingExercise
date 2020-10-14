using InvestmentPerformance.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPerformance.WebApi.Data.Mappings
{
    public class UserInvestmentMap : IEntityTypeConfiguration<UserInvestment>
    {
        public void Configure(EntityTypeBuilder<UserInvestment> builder)
        {
            builder.ToTable("UserInvestments", "dbo");
            builder.HasKey(ui => ui.Id);
            builder.Property(ui => ui.Id).HasColumnName("UserInvestmentId");
            builder.HasOne(ui => ui.Investment);
        }
    }
}
