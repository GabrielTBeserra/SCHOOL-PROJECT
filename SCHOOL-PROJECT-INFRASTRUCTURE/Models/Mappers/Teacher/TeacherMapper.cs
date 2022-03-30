using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCHOOL_PROJECT_DOMAIN.Entities.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Models.Mappers.Teacher
{
    internal class TeacherMapper : IEntityTypeConfiguration<TeacherEntity>
    {
        public void Configure(EntityTypeBuilder<TeacherEntity> builder)
        {
        }
    }
}
