namespace YemenExchangeApi.Services
{
    public interface IProccessData<TEntity>
    {
       IEnumerable<TEntity> GetShortData();
    }
}
