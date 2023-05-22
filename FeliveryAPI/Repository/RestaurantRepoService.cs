using FeliveryAPI.Data;

using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class RestaurantRepoService : IRepository<Restaurant> 
    {
        public IDbContextFactory<ElDbContext> Context { get; }

        public RestaurantRepoService(IDbContextFactory<ElDbContext> context)  //we may need base here
        {
            Context = context;
        }
        public List<Restaurant> GetAll()
        {
            List<Restaurant> RestaurantsList = new List<Restaurant>();

            using (var customContext = Context.CreateDbContext())
            {
                RestaurantsList = customContext.Restaurants.ToList();
            }

            return RestaurantsList;
        }

        public Restaurant? GetDetails(int id)
        {
            var RestaurantDetails = new Restaurant();
            using (var customContext = Context.CreateDbContext())
            {
                RestaurantDetails = customContext.Restaurants.Find(id);
            }
            return RestaurantDetails;

        }

        public void Insert(Restaurant restaurant)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Restaurants.Add(restaurant);
                customContext.SaveChanges();
            }
        }

        public void Update(Restaurant restaurant)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Restaurants.Update(restaurant);
                customContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Restaurants.Remove(customContext.Restaurants.Find(id));
                customContext.SaveChanges();
            }
        }
    }
}
