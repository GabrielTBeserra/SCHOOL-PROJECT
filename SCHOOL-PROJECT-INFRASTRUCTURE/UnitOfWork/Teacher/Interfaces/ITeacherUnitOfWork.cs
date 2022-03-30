using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Teacher.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Teacher.Interfaces
{
    public interface ITeacherUnitOfWork : IBaseConfigUnitOfWork
    {
        ISchoolTeacherRelationshipRepository SchoolTeacherRelationship { get; }
        ITeacherRepository TeacherRepository { get; }
        ISchoolUserRelationshipRepository SchoolUserRelationshipRepository { get; }
    }
}
