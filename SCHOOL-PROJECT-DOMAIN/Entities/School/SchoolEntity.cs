using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolTeacher;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL_PROJECT_DOMAIN.Entities.School
{
    [Table("School")]
    public class SchoolEntity
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
        public virtual ICollection<SchoolUserRelationship> Users { get; set; }
        public virtual ICollection<SchoolTeacherRelationship> Teachers { get; set; }

    }
}
