using SCHOOL_PROJECT_DOMAIN.Entities.School;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.School.Interfaces
{
    public interface ISchoolRepository : IGenericRepository<SCHOOL_PROJECT_DOMAIN.Entities.School.SchoolEntity>
    {
    }
}
