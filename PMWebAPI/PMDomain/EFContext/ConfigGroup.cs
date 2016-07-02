using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigGroup
    {
        public ConfigGroup(EntityTypeBuilder<Group> entityBuilder)
        {
            entityBuilder.HasKey(g => g.GroupId);
            entityBuilder.HasIndex(g => g.GroupName).IsUnique();
            entityBuilder.Property(g => g.GroupName).HasMaxLength(50);
            entityBuilder.Property(g => g.ModifiedDate).IsRequired();
            entityBuilder.Property(g => g.RowVersion).IsConcurrencyToken();

            entityBuilder.HasOne(g => g.Scene)
                         .WithMany(s => s.Groups)
                         .IsRequired(false);
            entityBuilder.HasOne(g => g.Project)
                         .WithMany(p => p.Groups)
                         .HasForeignKey(g=>g.ProjectId);
        }
    }
}
