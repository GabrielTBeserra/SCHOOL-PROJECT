using Microsoft.EntityFrameworkCore;
using SCHOOL_PROJECT_DOMAIN.Entities.Audit;
using SCHOOL_PROJECT_DOMAIN.Entities.School;
using SCHOOL_PROJECT_DOMAIN.Entities.Student;
using SCHOOL_PROJECT_DOMAIN.Entities.Teacher;
using SCHOOL_PROJECT_DOMAIN.Entities.User;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolTeacher;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LogEntity> Logs { get; set; }
        public DbSet<SchoolEntity> Schools { get; set; }
        public DbSet<SchoolUserRelationship> SchoolUserRelationship { get; set; }
        public DbSet<StudentEntity> Student { get; set; }
        public DbSet<TeacherEntity> Teacher { get; set; }
        public DbSet<SchoolTeacherRelationship> SchoolTeacherRelationship { get; set; }

    }
}
