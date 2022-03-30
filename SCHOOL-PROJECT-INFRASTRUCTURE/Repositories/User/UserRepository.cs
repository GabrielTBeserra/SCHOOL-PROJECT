using SCHOOL_PROJECT_DOMAIN.Entities.User;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.User.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.User
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
