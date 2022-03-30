using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Student.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Student.Interfaces
{
    public interface IStudentUnitOfWork : IBaseConfigUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        ISchoolUserRelationshipRepository SchoolUserRelationshipRepository { get; }
    }
}
