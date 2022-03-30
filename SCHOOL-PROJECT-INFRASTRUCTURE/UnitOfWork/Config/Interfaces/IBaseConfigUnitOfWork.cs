using System.Threading.Tasks;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.UnitOfWork.Config.Interfaces
{
    public interface IBaseConfigUnitOfWork
    {
        Task CommitAsync();
    }
}
