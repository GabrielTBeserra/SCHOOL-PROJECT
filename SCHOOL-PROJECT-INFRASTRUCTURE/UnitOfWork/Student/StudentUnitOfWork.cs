using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Student.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Student.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Student
{
    public class StudentUnitOfWork : BaseConfigUnitOfWork, IStudentUnitOfWork
    {
        public StudentUnitOfWork(ApplicationDbContext applicationDbContext, IStudentRepository studentRepository , ISchoolUserRelationshipRepository schoolUserRelationshipRepository) : base(applicationDbContext)
        {
            StudentRepository = studentRepository;
            SchoolUserRelationshipRepository = schoolUserRelationshipRepository;
        }

        public IStudentRepository StudentRepository { get; }

        public ISchoolUserRelationshipRepository SchoolUserRelationshipRepository { get; }
    }
}
