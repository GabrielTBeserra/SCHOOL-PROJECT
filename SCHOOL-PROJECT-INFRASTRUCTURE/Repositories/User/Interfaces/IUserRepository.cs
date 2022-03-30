using SCHOOL_PROJECT_DOMAIN.Entities.User;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.User.Interfaces
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
    }
}
