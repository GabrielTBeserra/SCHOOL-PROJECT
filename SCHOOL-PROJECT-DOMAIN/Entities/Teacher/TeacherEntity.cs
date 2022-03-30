using SCHOOL_PROJECT_DOMAIN.Entities.User;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolTeacher;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL_PROJECT_DOMAIN.Entities.Teacher
{
    [Table("Teacher")]
    public class TeacherEntity
    {
        [Key]
        [Column("code")]
        public int Id { get; set; }
        [Column("user_id")]
        [Required]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual ICollection<SchoolTeacherRelationship> Schools { get; set; }
    }
}
