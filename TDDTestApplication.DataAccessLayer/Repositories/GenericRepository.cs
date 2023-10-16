using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TDDTestApplication.DataAccessLayer.DataContext;
using TDDTestApplication.DataAccessLayer.Repositories.Interfaces;

namespace TDDTestApplication.DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GenericRepository(ApplicationDbContext aspNetCoreNTierDbContext)
        {
            _applicationDbContext = aspNetCoreNTierDbContext;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await (filter == null ? _applicationDbContext.Set<TEntity>().ToListAsync(cancellationToken) : _applicationDbContext.Set<TEntity>().Where(filter).ToListAsync(cancellationToken));
        }
    }
}