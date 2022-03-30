using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Teacher.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Teacher.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Teacher
{
    public class TeacherUnitOfWork : BaseConfigUnitOfWork, ITeacherUnitOfWork
    {
        public TeacherUnitOfWork(ApplicationDbContext applicationDbContext, ISchoolTeacherRelationshipRepository schoolTeacherRelationship, ITeacherRepository teacherRepository , ISchoolUserRelationshipRepository schoolUserRelationshipRepository) : base(applicationDbContext)
        {
            SchoolTeacherRelationship = schoolTeacherRelationship;
            TeacherRepository = teacherRepository;
            SchoolUserRelationshipRepository = schoolUserRelationshipRepository;
        }

        public ISchoolTeacherRelationshipRepository SchoolTeacherRelationship { get; }

        public ITeacherRepository TeacherRepository { get; }

        public ISchoolUserRelationshipRepository SchoolUserRelationshipRepository { get; }
    }
}
