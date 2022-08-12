using YemenExchangeApi.Models;

namespace YemenExchangeApi.Services
{
    public class AreaRepository : Repository<Area>, IProccessData<BaseModel<int, object>>
    {
        public AreaRepository(ExchangeDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<BaseModel<int, object>> GetShortData()
        {
            return GetAll().Select(e => new BaseModel<int, object> { Label = e.Description, Value = e.Id , ExtraValue = e.CityId });

        }
    }
}
