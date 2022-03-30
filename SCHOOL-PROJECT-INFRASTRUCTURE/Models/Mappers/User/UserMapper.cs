using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCHOOL_PROJECT_DOMAIN.Entities.User;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Models.Mappers.User
{
    public class UserMapper : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.EntityTypes)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
