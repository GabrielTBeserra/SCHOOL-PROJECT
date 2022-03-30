using SCHOOL_PROJECT_DOMAIN.Entities.Student;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Student.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Student
{
    public class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        
    }
}
