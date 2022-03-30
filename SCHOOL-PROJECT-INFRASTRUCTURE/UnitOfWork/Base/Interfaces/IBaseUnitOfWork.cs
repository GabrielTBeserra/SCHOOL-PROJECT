using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.User.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base.Interfaces
{
    public interface IBaseUnitOfWork : IBaseConfigUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
