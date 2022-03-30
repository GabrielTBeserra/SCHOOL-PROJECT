using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Audit.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.User.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.User.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.User
{
    public class AuthUnitOfWork : BaseConfigUnitOfWork, IAuthUnitOfWork
    {
        public AuthUnitOfWork(ApplicationDbContext applicationDbContext, IUserRepository userRepository, ILogRepository logRepository , ISchoolUserRelationshipRepository schoolUserRelationshipRepository) : base(applicationDbContext)
        {
            UserRepository = userRepository;
            LogRepository = logRepository;
            SchoolUserRelationshipRepository = schoolUserRelationshipRepository;
        }

        public IUserRepository UserRepository { get; }

        public ILogRepository LogRepository { get; }

        public ISchoolUserRelationshipRepository SchoolUserRelationshipRepository { get; }

    }
}
