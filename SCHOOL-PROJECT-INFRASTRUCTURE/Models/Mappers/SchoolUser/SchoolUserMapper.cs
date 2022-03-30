using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Models.Mappers.SchoolUser
{
    public class SchoolUserMapper : IEntityTypeConfiguration<SchoolUserRelationship>
    {
        public void Configure(EntityTypeBuilder<SchoolUserRelationship> builder)
        {
            builder.HasOne(x => x.School).WithMany(x => x.Users).HasForeignKey(x => x.SchoolId);
            builder.HasOne(x => x.User).WithMany(x => x.Schools).HasForeignKey(x => x.UserId);
            builder.Property(x => x.IsAdministrator).HasDefaultValue(false);
        }
    }
}
