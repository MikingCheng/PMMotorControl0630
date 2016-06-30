using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigSceneSegment
    {
        public ConfigSceneSegment(EntityTypeBuilder<SceneSegment> entityBuilder)
        {
            entityBuilder.HasKey(s => s.SceneSegmentId);
            entityBuilder.Property(s => s.SequenceNo).IsRequired();
            entityBuilder.Property(s => s.StartTime).HasMaxLength(4).IsRequired();

            entityBuilder.Property(s => s.ModifiedDate).IsRequired();
            entityBuilder.Property(s => s.RowVersion).IsConcurrencyToken();

            entityBuilder.HasOne(s => s.Scene).WithMany(s => s.SceneSegments).HasForeignKey(s => s.SceneId);
        }
    }
}
