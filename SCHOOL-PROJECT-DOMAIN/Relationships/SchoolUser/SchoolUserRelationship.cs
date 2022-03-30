using SCHOOL_PROJECT_DOMAIN.Entities.School;
using SCHOOL_PROJECT_DOMAIN.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser
{
    [Table("SchoolUser")]
    public class SchoolUserRelationship
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("school_id")]
        public int SchoolId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("administrator")]
        [Required]
        public bool IsAdministrator { get; set; }
        public virtual SchoolEntity School { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
