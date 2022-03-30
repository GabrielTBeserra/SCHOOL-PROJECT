using Microsoft.EntityFrameworkCore;
using SCHOOL_PROJECT_COMMON.Exceptions;
using SCHOOL_PROJECT_COMMON.Helpers.AuditContext;
using SCHOOL_PROJECT_COMMON.Helpers.ConvertContext;
using SCHOOL_PROJECT_COMMON.Helpers.Validators;
using SCHOOL_PROJECT_CROSSCUTING.DTO.User;
using SCHOOL_PROJECT_DOMAIN.Entities.User;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.User.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Auth.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Auth
{
    public class AuthApplicationService : IAuthApplicationService
    {
        private readonly IAuthUnitOfWork _uow;
        private readonly ITokenApplicationService tokenApplicationService;

        public AuthApplicationService(IAuthUnitOfWork uow, ITokenApplicationService tokenApplicationService)
        {
            _uow = uow;
            this.tokenApplicationService = tokenApplicationService;
        }

        public async Task<LoginResponseDto> Login(LoginDto dto, CancellationToken ctToken = default)
        {
            ctToken.ThrowIfCancellationRequested();

            var password = dto.Password.ToSha256();
            var user = await _uow.UserRepository.GetAllReadOnly()
                        .Include(x => x.EntityTypes)
                        .Where(user => user.Email == dto.Email && user.Password == password)
                        .FirstOrDefaultAsync(ctToken);

            if (user == null)
            {
                await _uow.LogRepository.AddAsync(AuditHelper.LogEntityWrongPassword(dto.Email));
                await _uow.CommitAsync();

                user.Invalid("Email or Password");
            }

            var userLogged = new LoginResponseDto
            {
                Token = tokenApplicationService.GenerateToken(user),
                UserType = user.EntityTypes.Select(x => new LoginUserType
                {
                    Type = x.Type,
                    TypeName = x.Name
                })
            };

            await _uow.LogRepository.AddAsync(AuditHelper.LogEntityLogin(user));
            await _uow.CommitAsync();

            return userLogged;
        }

        public async Task Register(RegisterDto dto, CancellationToken ctToken = default)
        {
            ctToken.ThrowIfCancellationRequested();

            var emailAlreadyRegisted = _uow.UserRepository.GetAllReadOnly().Any(user => user.Email == dto.Email);

            if (emailAlreadyRegisted)
            {
                throw new DomainException("User already registered.");
            }

            var newUser = new UserEntity
            {
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password.ToSha256(),
                LastName = dto.LastName,
                EntityTypes = new List<EntityTypesEntity>
                    {
                        new EntityTypesEntity
                        {
                            Type = 1,
                            Name = "Administrator"
                        }
                    }
            };

            await _uow.UserRepository.AddAsync(newUser);
            await _uow.LogRepository.AddAsync(AuditHelper.LogEntityRegister(newUser));

            await _uow.CommitAsync();
        }

    }
}
