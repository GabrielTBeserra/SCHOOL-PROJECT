using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCHOOL_PROJECT_CROSSCUTING.DTO.Student;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Student.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_INTERFACE.Controllers.Student
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]

    public class StudentController: ControllerBase
    {
        private readonly IStudentAppService _appService;

        public StudentController(IStudentAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Registrar alunos em uma escola
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Confirmação de registro")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("register")]
        public async Task<IActionResult> GetSchoolsUserAsAdmin([FromBody] StudentPostDto dto, CancellationToken ctToken)
        {
            await _appService.RegisterStudent(dto , ctToken);
            return Ok();
        }


    }
}
