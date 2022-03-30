using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.School.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.School.Interfaces
{
    public interface ISchoolUnitOfWork : IBaseConfigUnitOfWork
    {
        ISchoolRepository SchoolRepository { get; }
        ISchoolUserRelationshipRepository SchoolUserRelationshipRepository { get; }
        ISchoolTeacherRelationshipRepository SchoolTeacherRelationship { get; }
    }
}
