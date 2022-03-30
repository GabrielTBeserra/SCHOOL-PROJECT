using Microsoft.EntityFrameworkCore;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Repositories.Config
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddAsync(T obj)
        {
            await _applicationDbContext.Set<T>().AddAsync(obj);
        }

        public void Delete(T obj)
        {
            _applicationDbContext.Set<T>().Remove(obj);
        }

        public void Edit(T obj)
        {
            _applicationDbContext.Set<T>().Update(obj);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _applicationDbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAllReadOnly()
        {
            return _applicationDbContext.Set<T>().AsNoTracking();
        }
    }
}
