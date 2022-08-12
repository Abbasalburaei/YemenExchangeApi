using YemenExchangeApi.Models;

namespace YemenExchangeApi.Services
{
    public class CompanyRepository : Repository<Company> , IProccessData<BaseModel<string, object>>
    {
        public CompanyRepository(ExchangeDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<BaseModel<string, object>> GetShortData()
        {
            return GetAll().Select(e => new BaseModel<string, object> { Label = e.Description, Value = e.Id});

        }
    }
}
