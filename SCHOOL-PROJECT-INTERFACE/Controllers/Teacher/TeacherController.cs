using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCHOOL_PROJECT_CROSSCUTING.DTO.Teacher;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Teacher.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_INTERFACE.Controllers.Teacher
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherAppService _appService;

        public TeacherController(ITeacherAppService appService)
        {
            _appService = appService;
        }


        /// <summary>
        /// Registrar professores em uma escola
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
        public async Task<IActionResult> GetSchoolsUserAsAdmin([FromBody] TeacherPostDto dto, CancellationToken ctToken)
        {
            await _appService.RegisterTeacher(dto, ctToken);
            return Ok();
        }
    }
}
