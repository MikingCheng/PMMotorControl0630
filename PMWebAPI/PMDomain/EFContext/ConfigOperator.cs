using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.PMDomain.EFContext
{
    public class ConfigOperator
    {
        public ConfigOperator(EntityTypeBuilder<Operator> entityBuilder)
        {
            entityBuilder.HasKey(m => m.OperatorId);
            entityBuilder.Property(o => o.FirstName).HasMaxLength(30).IsRequired();
            entityBuilder.Property(o => o.LastName).HasMaxLength(30).IsRequired();
            entityBuilder.Property(o => o.UserName).HasMaxLength(20);
            entityBuilder.Property(o => o.Password).HasMaxLength(20);

            entityBuilder.Property(m => m.ModifiedDate).IsRequired();
            entityBuilder.Property(m => m.RowVersion).IsConcurrencyToken();

            entityBuilder.HasOne(o => o.Project)
                         .WithMany(p => p.Operators)
                         .HasForeignKey(o => o.ProjectId);
        }
    }
}
