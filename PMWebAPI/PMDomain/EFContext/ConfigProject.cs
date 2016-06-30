using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigProject
    {
        public ConfigProject(EntityTypeBuilder<Project> entityBuilder)
        {
            entityBuilder.HasKey(m => m.ProjectId);
            entityBuilder.Property(c => c.ProjectName).HasMaxLength(60).IsRequired();            // Name
            entityBuilder.Property(c => c.ProjectNumber).HasMaxLength(20).IsRequired();

            entityBuilder.Property(m => m.ModifiedDate).IsRequired();
            entityBuilder.Property(m => m.RowVersion).IsConcurrencyToken();
        }
    }
}
