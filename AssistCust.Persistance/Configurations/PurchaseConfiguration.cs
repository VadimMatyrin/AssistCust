using System;
using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssistCust.Persistance.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.Property(e => e.PurchaseTime)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(e => e.User).IsRequired();
            builder.HasOne(e => e.User)
                .WithMany(e => e.Purchases)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull); ;

            builder.Property(e => e.CompanyShop).IsRequired();
            builder.HasOne(e => e.CompanyShop)
                .WithMany(e => e.Purchases)
                .HasForeignKey(d => d.CompanyShopId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
