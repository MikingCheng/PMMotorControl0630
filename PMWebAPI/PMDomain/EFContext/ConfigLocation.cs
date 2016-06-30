using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigLocation
    {
        public ConfigLocation(EntityTypeBuilder<Location> entityBuilder)
        {
            entityBuilder.HasKey(e => e.LocaitonId);
            entityBuilder.Property(l => l.Building).HasMaxLength(80).IsRequired();
            entityBuilder.Property(l => l.Floor).HasMaxLength(20);
            entityBuilder.Property(l => l.RoomNo).HasMaxLength(50);
            entityBuilder.Property(l => l.CommAddress).HasMaxLength(40);
            entityBuilder.Property(l => l.DeviceSerialNo).HasMaxLength(16);
            entityBuilder.Property(l => l.Description).HasMaxLength(100);

            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsConcurrencyToken().IsRequired();

            // relationship
            entityBuilder.HasOne(l => l.Project)
                         .WithMany(p => p.Locations)
                         .HasForeignKey(l => l.ProjectId);
        }

    }
}

