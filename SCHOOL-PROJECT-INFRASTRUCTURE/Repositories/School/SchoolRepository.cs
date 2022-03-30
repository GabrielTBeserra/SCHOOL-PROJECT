using SCHOOL_PROJECT_DOMAIN.Entities.School;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.School.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.School
{
    public class SchoolRepository : GenericRepository<SCHOOL_PROJECT_DOMAIN.Entities.School.SchoolEntity>, ISchoolRepository
    {
        public SchoolRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
