using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config.Interfaces;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config
{
    public class BaseConfigUnitOfWork : IBaseConfigUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BaseConfigUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CommitAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
