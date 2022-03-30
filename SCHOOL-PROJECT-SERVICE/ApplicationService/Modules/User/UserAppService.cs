using Microsoft.EntityFrameworkCore;
using SCHOOL_PROJECT_CROSSCUTING.DTO.User;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.User.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.User.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.User
{
    internal class UserAppService : BaseApplicationService, IUserAppService
    {
        private readonly IAuthUnitOfWork _uow;
        public UserAppService(IBaseUnitOfWork unitOfWork, IAuthUnitOfWork uow) : base(unitOfWork)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<UserAsAdminSchoolListDto>> GetSchoolsUserAsAdmin(CancellationToken ct)
        {
            var user = await GetLoggedUserUntracked();
            
            var lista = _uow.SchoolUserRelationshipRepository.GetAllReadOnly().Include(x => x.School).Where(x => x.UserId == user.Id);
            var listaMap = await lista.Select(x => new UserAsAdminSchoolListDto
            {
                Nome = x.School.Name,
                Id = x.School.Id
            }).ToListAsync();

            return listaMap;
        }
    }
}
