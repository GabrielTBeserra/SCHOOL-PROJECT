using SCHOOL_PROJECT_DOMAIN.Entities.School;
using SCHOOL_PROJECT_DOMAIN.Entities.Teacher;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL_PROJECT_DOMAIN.Relationships.SchoolTeacher
{
    [Table("SchoolTeacher")]
    public class SchoolTeacherRelationship
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("school_id")]
        [Required]
        public int SchoolId { get; set; }
        [Column("teacher_id")]
        [Required]
        public int TeacherId { get; set; }
        public virtual TeacherEntity Teacher { get; set; }
        public virtual SchoolEntity School { get; set; }
    }
}
