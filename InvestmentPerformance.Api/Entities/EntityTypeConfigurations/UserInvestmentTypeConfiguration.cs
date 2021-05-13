using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InvestmentPerformance.Api.Entities.EntityTypeConfigurations
{
    public class UserInvestmentTypeConfiguration : IEntityTypeConfiguration<UserInvestment>
    {
        public void Configure(EntityTypeBuilder<UserInvestment> builder)
        {
            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.Active).HasDefaultValue(true);

            builder.HasMany(x => x.Purchases)
                .WithOne(p => p.UserInvestment)
                .HasForeignKey(p => p.UserInvestmentId);

            builder.HasOne(x => x.Investment)
                .WithMany()
                .HasForeignKey(x => x.InvestmentId);

            builder.HasIndex(x => new { x.UserId, x.InvestmentId })
                .IsUnique();

            builder.HasData(
                new UserInvestment { Id = 1, UserId = "sXybwQ7JaDJ88jxAkBpTRWepUF4wfKvi@clients", InvestmentId = 1, Active = true, CreatedDate = new DateTime(2020, 2, 13, 0, 0, 0, DateTimeKind.Utc), UpdatedDate = new DateTime(2020, 2, 13, 0, 0, 0, DateTimeKind.Utc) },
                new UserInvestment { Id = 2, UserId = "sXybwQ7JaDJ88jxAkBpTRWepUF4wfKvi@clients", InvestmentId = 3, Active = true, CreatedDate = new DateTime(2021, 1, 8, 0, 0, 0, DateTimeKind.Utc), UpdatedDate = new DateTime(2021, 1, 8, 0, 0, 0, DateTimeKind.Utc) },
                new UserInvestment { Id = 3, UserId = "sXybwQ7JaDJ88jxAkBpTRWepUF4wfKvi@clients", InvestmentId = 4, Active = false, CreatedDate = new DateTime(2020, 5, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedDate = new DateTime(2020, 5, 10, 0, 0, 0, DateTimeKind.Utc) },

                new UserInvestment { Id = 4, UserId = "anotherUserId", InvestmentId = 1, Active = true, CreatedDate = new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedDate = new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new UserInvestment { Id = 5, UserId = "anotherUserId", InvestmentId = 2, Active = false, CreatedDate = new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedDate = new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new UserInvestment { Id = 6, UserId = "anotherUserId2", InvestmentId = 1, Active = true, CreatedDate = new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedDate = new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new UserInvestment { Id = 7, UserId = "anotherUserId2", InvestmentId = 4, Active = true, CreatedDate = new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedDate = new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
