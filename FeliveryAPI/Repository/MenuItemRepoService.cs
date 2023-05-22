using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class MenuItemRepoService : BaseRepoService,IRepository<MenuItem>
    {
        public MenuItemRepoService(IDbContextFactory<ElDbContext> context) : base(context)
        {
        }
        public List<MenuItem> GetAll()
        {
            List<MenuItem> MenuItemList = new List<MenuItem>();

            using (var customContext = Context.CreateDbContext())
            {
                MenuItemList = customContext.MenuItems.ToList();
            }

            //using (var customContext = Context.CreateDbContext())
            //{
            //    foreach (var MenuItem in MenuItemList)
            //    {
            //        MenuItem.Restaurant = customContext.Restaurants.First(r => r.Id == MenuItem.RestaurantID);
            //        MenuItem.Category = customContext.Categories.First(c => c.Id == MenuItem.CategoryID);
            //    }
            //}

            return MenuItemList;
        }

        public MenuItem? GetDetails(int id)
        {
            var MenuItemDetails = new MenuItem();
            using (var customContext = Context.CreateDbContext())
            {
                MenuItemDetails = customContext.MenuItems.Find(id);
            }

            using (var customContext = Context.CreateDbContext())
            {
                MenuItemDetails.Restaurant = customContext.Restaurants.First(r => r.Id == MenuItemDetails.RestaurantID);
                MenuItemDetails.Category = customContext.Categories.First(r => r.Id == MenuItemDetails.CategoryID);
            }
            return (MenuItemDetails);
        }

        public void Insert(MenuItem t)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.MenuItems.Add(t);
                customContext.SaveChanges();
            }
        }

        public void Update(MenuItem menuitem)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.MenuItems.Update(menuitem);
                customContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.MenuItems.Remove(new MenuItem() { Id = id });
                customContext.SaveChanges();
            }
        }

    }
}
