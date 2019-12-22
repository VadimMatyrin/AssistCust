using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Persistance.Configurations
{
     public class IoTDeviceConfiguration : IEntityTypeConfiguration<IoTDevice>
    {
        public void Configure(EntityTypeBuilder<IoTDevice> builder)
        {
            builder.Property(e => e.RegistrationTime)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
