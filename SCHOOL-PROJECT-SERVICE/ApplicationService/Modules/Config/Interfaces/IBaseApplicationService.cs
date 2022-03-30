using SCHOOL_PROJECT_DOMAIN.Entities.User;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config.Interfaces
{
    public interface IBaseApplicationService
    {
        Task<UserEntity> GetLoggedUserUntracked();
        Task<UserEntity> GetLoggedUserTracked();
    }
}
