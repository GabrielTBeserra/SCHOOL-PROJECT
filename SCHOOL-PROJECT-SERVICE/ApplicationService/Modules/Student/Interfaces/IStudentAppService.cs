using SCHOOL_PROJECT_CROSSCUTING.DTO.Student;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Student.Interfaces
{
    public interface IStudentAppService
    {
        Task RegisterStudent(StudentPostDto dto, CancellationToken ctToken);
    }
}
