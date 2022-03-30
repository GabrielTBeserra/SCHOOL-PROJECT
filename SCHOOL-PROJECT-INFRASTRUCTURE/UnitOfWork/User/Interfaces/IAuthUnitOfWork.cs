using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Audit.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.User.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.User.Interfaces
{
    public interface IAuthUnitOfWork : IBaseConfigUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ILogRepository LogRepository { get; }
        ISchoolUserRelationshipRepository SchoolUserRelationshipRepository { get; }
    }
}
