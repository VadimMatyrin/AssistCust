using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.RegistrationDate)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
