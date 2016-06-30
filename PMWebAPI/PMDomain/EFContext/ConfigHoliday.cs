using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigHoliday
    {
        public ConfigHoliday(EntityTypeBuilder<Holiday> entityBuilder)
        {
            entityBuilder.HasKey(h => h.HolidayId);
            
            entityBuilder.Property(h => h.Day).HasMaxLength(4);

            entityBuilder.Property(h => h.ModifiedDate).IsRequired();
            entityBuilder.Property(h => h.RowVersion).IsConcurrencyToken();

            entityBuilder.HasOne(h => h.Project)
                         .WithMany(p => p.Holidays)
                         .HasForeignKey(h => h.HolidayId);
        }
    }
}
