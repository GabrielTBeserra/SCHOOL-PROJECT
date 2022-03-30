using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Audit;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Audit.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Relationships.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.School;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.School.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Student;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Student.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Teacher;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Teacher.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.User;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.User.Interfaces;

namespace SCHOOL_PROJECT_SERVICE.DependencyInjection.RepositoryInjection
{
    public static class ConfigureBindingsRepository
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<ISchoolUserRelationshipRepository, SchoolUserRelationshipRepository>();
            services.AddScoped<ISchoolTeacherRelationshipRepository, SchoolTeacherRelationshipRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
        }

    }
}
