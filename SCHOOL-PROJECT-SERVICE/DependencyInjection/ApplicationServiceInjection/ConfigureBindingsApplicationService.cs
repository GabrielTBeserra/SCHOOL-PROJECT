using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Auth;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Auth.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Config.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.School;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.School.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Student;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Student.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Teacher;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.Teacher.Interfaces;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.User;
using SCHOOL_PROJECT_SERVICE.ApplicationService.Modules.User.Interfaces;

namespace SCHOOL_PROJECT_SERVICE.DependencyInjection.ApplicationServiceInjection
{
    public static class ConfigureBindingsApplicationService
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenApplicationService, TokenApplicationService>();
            services.AddScoped<IBaseApplicationService, BaseApplicationService>();
            services.AddScoped<IStudentAppService, StudentAppService>();
            services.AddScoped<ITeacherAppService, TeacherAppService>();
            

            #region AUTH
            services.AddScoped<IAuthApplicationService, AuthApplicationService>();
            #endregion

            #region USER
            services.AddScoped<IUserAppService, UserAppService>();
            #endregion

            #region SCHOOL
            services.AddScoped<ISchoolAppService, SchoolAppService>();
            #endregion
        }
    }
}
