using KK.Uno.Server.Repositories.Base.ReadonlyRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KK.Uno.Server.Repositories.Base.EntityRepository
{
    public class EntityReadonlyRepositry<TEntity, TDbContext> : IAsyncReadonlyRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;

        protected EntityReadonlyRepositry(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().SingleOrDefaultAsync(expression);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().AnyAsync(expression);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().CountAsync(expression);
        }

        public Task<int> CountAsync()
        {
            return _dbContext.Set<TEntity>().CountAsync();
        }
    }
}
