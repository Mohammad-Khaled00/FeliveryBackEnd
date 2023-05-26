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
            List<Category> CategoriesList = new List<Category>();

            using (var customContext = Context.CreateDbContext())
            {
                CategoriesList = customContext.Categories.ToList();
            }
            return CategoriesList;
        }

        public Category GetDetails(int id)
        {

            
            using (var customContext = Context.CreateDbContext())
            {
                return customContext.Categories.Find(id);
            }
        }
        public void Insert(Category category)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Categories.Add(category);
                customContext.SaveChanges();
            }
        }
        public void Update(Category category)
        {

            using (var customContext = Context.CreateDbContext())
            {
                customContext.Categories.Update(category);
                customContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Categories.Remove(customContext.Categories.Find(id));
                customContext.SaveChanges();
            }
        }

    }
}
