using Microsoft.EntityFrameworkCore.Storage;

namespace KK.Uno.Server.Repositories.Base.ReadonlyRepository
{
    public interface IAsyncRepository<TEntity> : IAsyncReadonlyRepository<TEntity>
        where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);

        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
