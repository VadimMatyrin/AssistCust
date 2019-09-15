using System;
using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssistCust.Persistance.Configurations
{
    public class PurchaseDetailConfiguration : IEntityTypeConfiguration<PurchaseDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseDetail> builder)
        {
            builder.Property(e => e.Amount)
                .IsRequired();

            builder.Property(e => e.Product)
               .IsRequired();

            builder.Property(e => e.Product).IsRequired();
            builder.HasOne(e => e.Product)
                .WithMany(e => e.PurchaseDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull); ;
        }
    }
}
