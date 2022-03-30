using SCHOOL_PROJECT_CROSSCUTING.DTO.Teacher;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Teacher.Interfaces
{
    public interface ITeacherAppService
    {
        Task RegisterTeacher(TeacherPostDto dto, CancellationToken ctToken);
    }
}
