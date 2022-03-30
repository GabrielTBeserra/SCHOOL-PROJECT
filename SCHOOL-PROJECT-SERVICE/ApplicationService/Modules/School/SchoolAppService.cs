using Microsoft.EntityFrameworkCore;
using SCHOOL_PROJECT_COMMON.Helpers.Validators;
using SCHOOL_PROJECT_CROSSCUTING.DTO.School;
using SCHOOL_PROJECT_DOMAIN.Entities.School;
using SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.School.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.School.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.School
{
    public class SchoolAppService : BaseApplicationService, ISchoolAppService
    {
        private readonly ISchoolUnitOfWork _uow;

        public SchoolAppService(IBaseUnitOfWork unitOfWork, ISchoolUnitOfWork uow) : base(unitOfWork)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<GetAllStudentsDto>> AllStudents(CancellationToken ct)
        {
            var loggedUser = GetLoggedUserTrackedQuery();
            var schoolFromUser = loggedUser.Include(x => x.Schools).FirstOrDefault().Schools.FirstOrDefault(x => x.IsAdministrator);

            if(schoolFromUser != null)
            {
                var school = _uow.SchoolUserRelationshipRepository.GetAllReadOnly()
                                                                .Include(x => x.User)
                                                                .ThenInclude(x => x.Students)
                                                                .Where(x => x.SchoolId == schoolFromUser.SchoolId 
                                                                                        && x.IsAdministrator == false 
                                                                                        && x.UserId != schoolFromUser.UserId);

                var students = await school.Select(x => new GetAllStudentsDto
                {
                    Id = x.User.Id,
                    Name = $"{x.User.Name} {x.User.LastName}",
                    Registration = x.User.Students.FirstOrDefault().Registration
                }).ToListAsync(ct);

                return students;
            }


            return null;
        }

        public async Task<IEnumerable<GetAllTeachersDto>> AllTeachers(CancellationToken ct)
        {
            var loggedUser = GetLoggedUserTrackedQuery();
            var schoolFromUser = loggedUser.Include(x => x.Schools).FirstOrDefault().Schools.FirstOrDefault(x => x.IsAdministrator);

            if (schoolFromUser != null)
            {
                var school =  _uow.SchoolTeacherRelationship.GetAllReadOnly()
                                                                .Include(x => x.Teacher)
                                                                .ThenInclude(x => x.User)
                                                                .Where(x => x.SchoolId == schoolFromUser.SchoolId);

                var teachers = await school.Select(x => new GetAllTeachersDto
                {
                    Id = x.Id,
                    Name = $"{x.Teacher.User.Name} {x.Teacher.User.LastName}",
                }).ToListAsync(ct);

                return teachers;
            }


            return null;
        }

        public async Task RegisterSchoolAsync(SchoolCreateDto dto, CancellationToken ct)
        {
            var alreadyExits = await _uow.SchoolRepository.GetAllReadOnly().AnyAsync(x => x.Name == dto.Name);

            alreadyExits.AlreadyExits("School");

            var school = new SCHOOL_PROJECT_DOMAIN.Entities.School.SchoolEntity
            {
                Email = dto.Email,
                Name = dto.Name,
                Users = new List<SchoolUserRelationship>
                {
                    new SchoolUserRelationship
                    {
                        User = await GetLoggedUserTracked(),
                        IsAdministrator = true
                    }
                }
            };

            await _uow.SchoolRepository.AddAsync(school);
            await _uow.CommitAsync();
        }
    }
}
