using SCHOOL_PROJECT_CROSSCUTING.DTO.User;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.User.Interfaces
{
    public interface IUserAppService
    {
        Task<IEnumerable<UserAsAdminSchoolListDto>> GetSchoolsUserAsAdmin(CancellationToken ct);
    }
}
