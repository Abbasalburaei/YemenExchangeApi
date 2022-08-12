using System.Linq.Expressions;
namespace YemenExchangeApi.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ExchangeDbContext dbContext;

        public Repository(ExchangeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
           await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<int> CompleteAsync()
        {
          return await dbContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
           return dbContext.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
           return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetByIdAsync(string id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public  IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
          dbContext.Set<TEntity>().Update(entity);
        }

    }
}
