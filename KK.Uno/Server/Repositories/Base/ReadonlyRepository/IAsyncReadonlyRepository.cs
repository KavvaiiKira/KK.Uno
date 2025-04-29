using System.Linq.Expressions;

namespace KK.Uno.Server.Repositories.Base.ReadonlyRepository
{
    public interface IAsyncReadonlyRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);

        Task<int> CountAsync();
    }
}
