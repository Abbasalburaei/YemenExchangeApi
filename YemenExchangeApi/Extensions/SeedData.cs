using Microsoft.EntityFrameworkCore;
using YemenExchangeApi.Models;
namespace YemenExchangeApi.Extensions
{
    /// <summary>
    /// to initialize base data to objects
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// to initialize values to main tables such as [cities-areas-companies]
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            IList<City> citiesList = new List<City>
            {
                new City(){Id = 1 , Description = "صنعاء"},
                new City(){Id = 2 ,Description = "تعز"},
                new City(){Id = 3 ,Description = "الحديدة"},
                new City(){Id = 4 ,Description = "عدن"},
                new City(){Id = 5 ,Description = "إب"},
                new City(){Id = 6 ,Description = "ذمار"},
                new City(){Id = 7 ,Description = "المكلا"},
                new City(){Id = 8 ,Description = "سيئون"},
                new City(){Id = 9 ,Description = "سيان"},
                new City(){Id = 10 ,Description = "الشحر"},
                new City(){Id = 11 ,Description = "زبيد"},
                new City(){Id = 12 ,Description = "حجة"},
                new City(){Id = 13 ,Description = "باجل"},
                new City(){Id = 14 ,Description = "رداع"},
                new City(){Id = 15 ,Description = "سقطرى"},
                new City(){Id = 16 ,Description = "بيت الفقية"},
                new City(){Id = 17 ,Description = "يريم"},
                new City(){Id = 18 ,Description = "البيضاء"},
                new City(){Id = 19 ,Description = "لحج"},
                new City(){Id = 20 ,Description = "عبس"},
                new City(){Id = 21 ,Description = "حرض"},
                new City(){Id = 22 ,Description = "مديرية المحابشة"},
                new City(){Id = 23 ,Description = "مأرب"},
                new City(){Id = 24 ,Description = "عمران"},
                new City(){Id = 25 ,Description = "المخا"},
                new City(){Id = 26 ,Description = "المحويت"},
            };
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasData(citiesList.ToArray());
            });
        }
    }
}
