using Microsoft.EntityFrameworkCore;
using SCHOOL_PROJECT_CROSSCUTING.DTO.Student;
using SCHOOL_PROJECT_DOMAIN.Entities.Student;
using SCHOOL_PROJECT_DOMAIN.Entities.User;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Student.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Student.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Student
{
    public class StudentAppService : BaseApplicationService, IStudentAppService
    {
        private readonly IStudentUnitOfWork _uow;

        public StudentAppService(IBaseUnitOfWork unitOfWork, IStudentUnitOfWork uow) : base(unitOfWork)
        {
            _uow = uow;
        }

        public async Task RegisterStudent(StudentPostDto dto, CancellationToken ctToken)
        {
            var loggedUserId = await GetLoggedUserTracked();
            var school = await _uow.SchoolUserRelationshipRepository.GetAll().FirstOrDefaultAsync(x => x.User.Id == loggedUserId.Id && x.IsAdministrator);
            var userAlready = await BaseUnitOfWork.UserRepository.GetAll().Include(x => x.EntityTypes).FirstOrDefaultAsync(x => x.Email == dto.Email);

            Random rnd = new Random();

            var student = new StudentEntity
            {
                User = new UserEntity
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    LastName = dto.LastName,
                    Password = Guid.NewGuid().ToString(),
                    Schools = new List<SchoolUserRelationship>
                    {
                        new SchoolUserRelationship
                        {
                            SchoolId = school.SchoolId
                        }
                    },
                    

                },
                Registration = rnd.Next(1, int.MaxValue)
            };

            if (userAlready != null)
            {
                student.User = userAlready;
                if (userAlready.EntityTypes.Any())
                {
                    userAlready.EntityTypes.Add(new EntityTypesEntity
                    {
                        Type = 3,
                        Name = "Student"
                    });
                } else
                {
                    student.User.EntityTypes = new List<EntityTypesEntity>
                    {
                        new EntityTypesEntity
                        {
                            Type = 3,
                            Name = "Student"
                        }
                    };
                }
            }

            await _uow.StudentRepository.AddAsync(student);
            await _uow.CommitAsync();
        }
    }
}
