using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigEvent
    {
        public ConfigEvent(EntityTypeBuilder<Event> entityBuilder)
        {
            entityBuilder.HasKey(e => e.EventId);
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsConcurrencyToken().IsRequired();

            entityBuilder.HasOne(e => e.Project)
                         .WithMany(p => p.Events)
                         .HasForeignKey(e => e.ProjectId);
//                         .IsRequired(false);
            entityBuilder.HasOne(e => e.Location)
                         .WithMany(l => l.Events)
                         .HasForeignKey(e => e.LocationId)
                         .IsRequired(false);
            entityBuilder.HasOne(e => e.EventMessage)
                         .WithMany(m => m.Events)
                         .HasForeignKey(e => e.EventMessageId);
        }
    }
}
