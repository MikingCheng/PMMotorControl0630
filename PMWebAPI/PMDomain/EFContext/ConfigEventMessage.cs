using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigEventMessage
    {
        public ConfigEventMessage(EntityTypeBuilder<EventMessage> entityBuilder)
        {
            entityBuilder.HasKey(m => m.EventMessageId);
            entityBuilder.Property(m => m.Message).HasMaxLength(100);
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsConcurrencyToken().IsRequired();
        }
    }
}
