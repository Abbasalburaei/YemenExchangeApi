using YemenExchangeApi.Models;
using YemenExchangeApi.Services;

namespace YemenExchangeApi.Providers
{
    public class RepositoryProvider 
    {
        private readonly ExchangeDbContext dbContext;

        public RepositoryProvider(ExchangeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Area> GetAreas()
        {
            return dbContext.Areas.ToList();
        }

        public IList<City> GetCities()
        {
            return dbContext.Cities.ToList();
        }

        public IList<Company> GetCompanies()
        {
            return dbContext.Companies.ToList();
        }

        public IList<Customer> GetCustomers()
        {
            return dbContext.Customers.ToList();
        }
    }
}
