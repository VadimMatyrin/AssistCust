using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssistCust.Persistance.Configurations
{
    public class CompanyShopConfiguration : IEntityTypeConfiguration<CompanyShop>
    {
        public void Configure(EntityTypeBuilder<CompanyShop> builder)
        {
            builder.Property(e => e.ShopName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.AddressField1)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.AddressField2)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.City).IsRequired()
                .HasMaxLength(25);

            builder.HasOne(e => e.Company)
                .WithMany(e => e.CompanyShops)
                .HasForeignKey(d => d.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
