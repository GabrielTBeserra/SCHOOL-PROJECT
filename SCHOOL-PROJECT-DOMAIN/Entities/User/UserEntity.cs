using SCHOOL_PROJECT_DOMAIN.Entities.Student;
using SCHOOL_PROJECT_DOMAIN.Entities.Teacher;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL_PROJECT_DOMAIN.Entities.User
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("lastname")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [Column("password")]
        [MaxLength(100)]
        public string Password { get; set; }
        public virtual ICollection<SchoolUserRelationship> Schools { get; set; }
        public virtual ICollection<StudentEntity> Students { get; set; }
        public virtual ICollection<TeacherEntity> Teachers { get; set; }
        public virtual ICollection<EntityTypesEntity> EntityTypes { get; set; }
    }
}
 