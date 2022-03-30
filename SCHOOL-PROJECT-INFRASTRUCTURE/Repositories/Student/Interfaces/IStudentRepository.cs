using SCHOOL_PROJECT_DOMAIN.Entities.Student;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Teacher;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Student.Interfaces
{
    public interface IStudentRepository : IGenericRepository<StudentEntity>
    {
        
    }
}
