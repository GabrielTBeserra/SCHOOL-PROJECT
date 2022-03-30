using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Base.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.School;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.School.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Student;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Student.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Teacher;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Teacher.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.User;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.User.Interfaces;

namespace SCHOOL_PROJECT_SERVICE.DependencyInjection.UnitOfWorkInjection
{
    public static class ConfigureBindinsUnifOfWorks
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthUnitOfWork, AuthUnitOfWork>();
            services.AddScoped<IBaseConfigUnitOfWork, BaseConfigUnitOfWork>();
            services.AddScoped<IBaseUnitOfWork, BaseUnitOfWork>();
            services.AddScoped<ISchoolUnitOfWork, SchoolUnitOfWork>();
            services.AddScoped<IStudentUnitOfWork, StudentUnitOfWork>();
            services.AddScoped<ITeacherUnitOfWork, TeacherUnitOfWork>();
        }
    }
}
