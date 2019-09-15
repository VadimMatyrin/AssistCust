using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssistCust.Persistance.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.CreatedBy).IsRequired();
        }
    }
}
