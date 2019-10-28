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

            builder.HasOne(e => e.User)
                .WithMany(e => e.Purchases)
                .HasForeignKey(d => d.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull); ;

            builder.HasOne(e => e.CompanyShop)
                .WithMany(e => e.Purchases)
                .HasForeignKey(d => d.CompanyShopId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
