using Microsoft.EntityFrameworkCore;
using SCHOOL_PROJECT_CROSSCUTING.DTO.Teacher;
using SCHOOL_PROJECT_DOMAIN.Entities.Teacher;
using SCHOOL_PROJECT_DOMAIN.Entities.User;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolTeacher;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Teacher.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Teacher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Teacher
{
    public class TeacherAppService : BaseApplicationService, ITeacherAppService
    {
        private readonly ITeacherUnitOfWork _uow;
        public TeacherAppService(IBaseUnitOfWork unitOfWork, ITeacherUnitOfWork uow) : base(unitOfWork)
        {
            _uow = uow;
        }

        public async Task RegisterTeacher(TeacherPostDto dto, CancellationToken ctToken)
        {
            var loggedUserId = await GetLoggedUserTracked();
            var school = await _uow.SchoolUserRelationshipRepository.GetAll().FirstOrDefaultAsync(x => x.User.Id == loggedUserId.Id && x.IsAdministrator);
            var userAlready = await BaseUnitOfWork.UserRepository.GetAll().Include(x => x.EntityTypes).FirstOrDefaultAsync(x => x.Email == dto.Email);

            Random rnd = new Random();

            var teacher = new TeacherEntity
            {
                User = new UserEntity
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    LastName = dto.LastName,
                    Password = Guid.NewGuid().ToString(),
                    EntityTypes = new List<EntityTypesEntity>
                    {
                        new EntityTypesEntity
                        {
                            Type = 2,
                            Name = "Teacher"
                        }
                    }
                },
                Schools = new List<SchoolTeacherRelationship>
                {
                    new SchoolTeacherRelationship
                    {
                        SchoolId = school.SchoolId
                    }
                }
            };


            if (userAlready != null)
            {
                teacher.User = userAlready;
                if (userAlready.EntityTypes.Any())
                {
                    userAlready.EntityTypes.Add(new EntityTypesEntity
                    {
                        Type = 2,
                        Name = "Teacher"
                    });
                }
                else
                {
                    teacher.User.EntityTypes = new List<EntityTypesEntity>
                    {
                        new EntityTypesEntity
                        {
                            Type = 2,
                            Name = "Teacher"
                        }
                    };
                }
            }

            await _uow.TeacherRepository.AddAsync(teacher);
            await _uow.CommitAsync();
        }
    }
}
