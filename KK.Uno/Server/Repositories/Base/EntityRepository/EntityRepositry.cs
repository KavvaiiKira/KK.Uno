using KK.Uno.Server.Repositories.Base.ReadonlyRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace KK.Uno.Server.Repositories.Base.EntityRepository
{
    public abstract class EntityRepositry<TEntity, TDbContext> : EntityReadonlyRepositry<TEntity, TDbContext>, IAsyncRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected EntityRepositry(TDbContext context) : base(context)
        {

        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }
    }
}
