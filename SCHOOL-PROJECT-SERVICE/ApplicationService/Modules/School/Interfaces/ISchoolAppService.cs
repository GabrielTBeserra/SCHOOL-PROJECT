using SCHOOL_PROJECT_CROSSCUTING.DTO.School;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.School.Interfaces
{
    public interface ISchoolAppService : IBaseApplicationService
    {
        Task RegisterSchoolAsync(SchoolCreateDto dto , CancellationToken ct);
        Task<IEnumerable<GetAllStudentsDto>> AllStudents(CancellationToken ct);
        Task<IEnumerable<GetAllTeachersDto>> AllTeachers(CancellationToken ct);
    }
}
