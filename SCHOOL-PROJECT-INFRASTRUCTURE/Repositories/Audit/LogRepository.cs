using SCHOOL_PROJECT_DOMAIN.Entities.Audit;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Audit.Interfaces;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Audit
{
    public class LogRepository : GenericRepository<LogEntity>, ILogRepository
    {
        public LogRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }


}
