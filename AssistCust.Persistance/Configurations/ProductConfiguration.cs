using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssistCust.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(e => e.Company)
                .WithMany(e => e.Products)
                .HasForeignKey(d => d.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
