using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigScene
    {
        public ConfigScene(EntityTypeBuilder<Scene> entityBuilder)
        {
            entityBuilder.HasKey(s=>s.SceneId);
            entityBuilder.Property(s => s.SceneName).IsRequired().HasMaxLength(50);

            entityBuilder.Property(s => s.ModifiedDate).IsRequired();
            entityBuilder.Property(s => s.RowVersion).IsConcurrencyToken();

            entityBuilder.HasOne(s => s.Project).WithMany(p => p.Scenes).HasForeignKey(s => s.ProjectId);
        }
    }
}
