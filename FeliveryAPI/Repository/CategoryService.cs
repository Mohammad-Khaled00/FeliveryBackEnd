using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class CategoryService : BaseRepoService, IRepository<Category>
    {
        public CategoryService(IDbContextFactory<ElDbContext> context) : base(context)
        {
        }

        public List<Category> GetAll()
        {
            List<Category> CategoriesList = new();
            using (var customContext = Context.CreateDbContext())
            {
                CategoriesList = customContext.Categories.ToList();
            }
            using (var customContext = Context.CreateDbContext())
            {
                foreach (var ctg in CategoriesList)
                {
                    ctg.Restaurant = customContext.Restaurants.First(r => r.Id == ctg.RestaurantID);
                }
            }
            return CategoriesList;
        }

        public Category GetDetails(int id)
        {
            var CategoryDetails = new Category();
            using (var customContext = Context.CreateDbContext())
            {
                CategoryDetails = customContext.Categories.Find(id);
            }
            using (var customContext = Context.CreateDbContext())
            {
                CategoryDetails.Restaurant = customContext.Restaurants.First(r => r.Id == CategoryDetails.RestaurantID);
            }
            return CategoryDetails;
        }

        public void Insert(Category category)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Categories.Add(category);
            customContext.SaveChanges();
        }

        public void Update(Category category)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Categories.Update(category);
            customContext.SaveChanges();
        }

        public Category Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            Category CategoryData = customContext.Categories.Find(id);
            customContext.Categories.Remove(CategoryData);
            customContext.SaveChanges();
            return CategoryData;
        }
    }
}
