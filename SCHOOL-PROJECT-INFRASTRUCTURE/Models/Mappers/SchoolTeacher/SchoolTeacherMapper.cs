using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolTeacher;
using System;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Models.Mappers.SchoolTeacher
{
    public class SchoolTeacherMapper : IEntityTypeConfiguration<SchoolTeacherRelationship>
    {
        public void Configure(EntityTypeBuilder<SchoolTeacherRelationship> builder)
        {
            builder.HasOne(x => x.School).WithMany(x => x.Teachers).HasForeignKey(x => x.SchoolId);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Schools).HasForeignKey(x => x.TeacherId);
        }
    }
}
