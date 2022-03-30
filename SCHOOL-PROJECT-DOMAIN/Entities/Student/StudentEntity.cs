using SCHOOL_PROJECT_DOMAIN.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL_PROJECT_DOMAIN.Entities.Student
{
    [Table("Student")]
    public class StudentEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("registration")]
        [Required]
        public int Registration { get; set; }

        [Column("user_id")]
        [Required]
        public int UserId { get; set; }

        public virtual UserEntity User { get; set; }

    }
}
