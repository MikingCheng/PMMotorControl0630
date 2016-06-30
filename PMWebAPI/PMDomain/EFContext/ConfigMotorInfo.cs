using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigMotorInfo
    {
        public ConfigMotorInfo(EntityTypeBuilder<MotorInfo> entityBuilder)
        {
            entityBuilder.HasKey(m => m.MotorInfoId);

            entityBuilder.Property( m=> m.ModifiedDate).IsRequired();
            entityBuilder.Property(m => m.RowVersion).IsConcurrencyToken();
        }
    }
}
