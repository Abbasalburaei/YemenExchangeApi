using YemenExchangeApi.Models;

namespace YemenExchangeApi.Services
{
    public class CustomerRepository : Repository<Customer>, IProccessData<BaseModel<string, object>>
    {
        private const string PREFIX = "Cus";
        public CustomerRepository(ExchangeDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<BaseModel<string, object>> GetShortData()
        {
            return GetAll().Select(e => new BaseModel<string, object> { Label = e.FullName, Value = e.Id });
        }
        public string GenerateCode()
        {
            var result = FindAll(e => e.Id.ToLower().StartsWith(PREFIX.ToLower())).Select(e => Convert.ToInt64(e.Id.Trim().Substring(PREFIX.Length))).ToList();
            if (result.Count != 0)
                return String.Concat(PREFIX, (1 + result.Max()));

            return String.Concat(PREFIX, 1);
        }
        public string GenerateCode(List<string> values)
        {
            var result = values.Where(e => e.ToLower().StartsWith(PREFIX.ToLower())).Select(e => Convert.ToInt64(e.Trim().Substring(PREFIX.Length))).ToList();
            if (result.Count != 0)
                return String.Concat(PREFIX, (1 + result.Max()));

            return String.Concat(PREFIX, 1);
        }
    }
}
