using Microsoft.EntityFrameworkCore;
using SCHOOL_PROJECT_COMMON.Exceptions;
using SCHOOL_PROJECT_COMMON.Helpers.HttpContext;
using SCHOOL_PROJECT_DOMAIN.Entities.User;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config
{
    public class BaseApplicationService : IBaseApplicationService
    {
        protected readonly IBaseUnitOfWork BaseUnitOfWork;

        public BaseApplicationService(IBaseUnitOfWork unitOfWork)
        {
            BaseUnitOfWork = unitOfWork;
        }

        public async Task<UserEntity> GetLoggedUserTracked()
        {
            var loggedUserName = HttpHelper.LoggedUser;
            var user = await BaseUnitOfWork.UserRepository.GetAll().Where(x => x.Email == loggedUserName).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new DomainException("User not found");
            }

            return user;
        }

        public IQueryable<UserEntity> GetLoggedUserTrackedQuery()
        {
            var loggedUserName = HttpHelper.LoggedUser;
            var user = BaseUnitOfWork.UserRepository.GetAll().Where(x => x.Email == loggedUserName);

            if (user == null)
            {
                throw new DomainException("User not found");
            }

            return user;
        }


        public async Task<UserEntity> GetLoggedUserUntracked()
        {
            var loggedUserName = HttpHelper.LoggedUser;
            var user = await BaseUnitOfWork.UserRepository.GetAll().Where(x => x.Email == loggedUserName).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new DomainException("User not found");
            }

            return user;
        }


    }
}
