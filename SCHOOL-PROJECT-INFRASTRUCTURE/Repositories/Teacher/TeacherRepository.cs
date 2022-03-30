using SCHOOL_PROJECT_DOMAIN.Entities.Teacher;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Teacher.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Teacher
{
    public class TeacherRepository : GenericRepository<TeacherEntity>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
