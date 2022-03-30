using SCHOOL_PROJECT_DOMAIN.Entities.User;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config.Interfaces
{
    public interface ITokenApplicationService
    {
        string GenerateToken(UserEntity user);
    }
}
