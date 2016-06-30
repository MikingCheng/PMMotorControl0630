using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigInstalledMotor
    {
        public ConfigInstalledMotor(EntityTypeBuilder<InstalledMotor> entityBuilder)
        {
            entityBuilder.HasKey(m => m.InstalledMotorId);

            entityBuilder.Property( m=> m.ModifiedDate).IsRequired();
            entityBuilder.Property(m => m.RowVersion).IsConcurrencyToken();

            entityBuilder.HasOne(m => m.Location)
                         .WithOne(l => l.InstallMotor)
                         .HasForeignKey<InstalledMotor>(m => m.LocationId);
            entityBuilder.HasOne(m => m.MotorInfo)
                         .WithMany(i => i.InstalledMotors)
                         .IsRequired(false);

        }
    }
}
