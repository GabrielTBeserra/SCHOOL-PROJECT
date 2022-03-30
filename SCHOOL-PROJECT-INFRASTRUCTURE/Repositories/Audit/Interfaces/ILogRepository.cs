using SCHOOL_PROJECT_DOMAIN.Entities.Audit;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config.Interfaces;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Audit.Interfaces
{
    public interface ILogRepository : IGenericRepository<LogEntity>
    {
    }


}
