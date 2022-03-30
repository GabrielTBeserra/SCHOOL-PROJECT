using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.User.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base
{
    public class BaseUnitOfWork : BaseConfigUnitOfWork, IBaseUnitOfWork
    {
        public BaseUnitOfWork(ApplicationDbContext applicationDbContext, IUserRepository userRepository) : base(applicationDbContext)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }
    }
}
