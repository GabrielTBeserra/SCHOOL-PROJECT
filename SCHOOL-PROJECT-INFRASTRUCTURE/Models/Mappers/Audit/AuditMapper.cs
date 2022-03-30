using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCHOOL_PROJECT_DOMAIN.Entities.Audit;
using System;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Models.Mappers.Audit
{
    public class AuditMapper : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.Property(x => x.LogTime)
                   .HasColumnType("datetime")
                   .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Id)
                   .HasColumnType("varchar(36)");
        }
    }
}
