using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigGroupInstalledMotor
    {
        public ConfigGroupInstalledMotor(EntityTypeBuilder<GroupInstalledMotor> entityBuilder)
        {
            //            entityBuilder.HasKey(gm => new { gm.GroupId, gm.InstalledMotorId });
            entityBuilder.HasKey(gm => gm.GroupInstalledMotorId);

            entityBuilder.HasOne(gm => gm.Group)
                         .WithMany(g => g.GroupInstalledMotors)
                         .HasForeignKey(gm => gm.GroupId)
                         .IsRequired(false);

            entityBuilder.HasOne(gm => gm.InstalledMotor)
                         .WithMany(m => m.GroupInstalledMotors)
                         .HasForeignKey(gm => gm.InstalledMotorId)
                         .IsRequired(false);
                         
        }
    }
}
