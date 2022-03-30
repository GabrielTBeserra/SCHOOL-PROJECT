using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCHOOL_PROJECT_CROSSCUTING.DTO.School;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.School.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_INTERFACE.Controllers.School
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolAppService _appService;

        public SchoolController(ISchoolAppService appService)
        {
            _appService = appService;
        }


        /// <summary>
        /// Rota para Criação de escola
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Create with Success")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SchoolCreateDto dto, CancellationToken ctToken)
        {
            await _appService.RegisterSchoolAsync(dto, ctToken);
            return Ok();
        }


        /// <summary>
        /// Rota para Obter todos alunos matriculados
        /// </summary>
        /// <param name="dto"></param>https://localhost:5001/swagger/index.html
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Success" , Type = typeof(IEnumerable<GetAllStudentsDto>))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("students")]
        public async Task<IActionResult> AllStudents(CancellationToken ctToken) => Ok(await _appService.AllStudents(ctToken));

        /// <summary>
        /// Rota para Obter todos alunos matriculados
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ctToken"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Success" , Type = typeof(IEnumerable<GetAllTeachersDto>))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [SwaggerResponse(statusCode: 404, description: "User not found", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("teachers")]
        public async Task<IActionResult> AllTeachers(CancellationToken ctToken) => Ok(await _appService.AllTeachers(ctToken));
    }
}
