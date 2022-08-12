using YemenExchangeApi.Models;

namespace YemenExchangeApi.Services
{
    public class CityRepository : Repository<City>, IProccessData<BaseModel<int, object>>
    {
        public CityRepository(ExchangeDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<BaseModel<int,object>> GetShortData()
        {
            return GetAll().Select(e => new BaseModel<int, object> { Label = e.Description, Value = e.Id });
        }
    }
}
