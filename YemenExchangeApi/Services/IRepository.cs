using System.Linq.Expressions;
namespace YemenExchangeApi.Services
{
    /// <summary>
    /// interface to apply repository pattern on the dbcontext data
    /// </summary>
    /// <typeparam name="TEntity">generic type</typeparam>
    public interface IRepository <TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity?> GetByIdAsync(string id);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task<int> CompleteAsync();

    }
}
