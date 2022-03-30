using SCHOOL_PROJECT_CROSSCUTING.DTO.User;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Auth.Interfaces
{
    public interface IAuthApplicationService
    {
        Task<LoginResponseDto> Login(LoginDto dto, CancellationToken ctToken);
        Task Register(RegisterDto dto, CancellationToken ctToken);
    }
}
