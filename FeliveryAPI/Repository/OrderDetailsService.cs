using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class OrderDetailsService : BaseRepoService, IRepository<OrderDetails>
    {
        public OrderDetailsService(IDbContextFactory<ElDbContext> context) : base(context)
        {
        }
        public List<OrderDetails> GetAll()

        {
            List<OrderDetails> CategoriesList = new();

            using (var customContext = Context.CreateDbContext())
            {
                CategoriesList = customContext.OrderDetails.ToList();
            }
            return CategoriesList;
        }

        public OrderDetails GetDetails(int id)
        {


            using var customContext = Context.CreateDbContext();
            return customContext.OrderDetails.Find(id);
        }
        public void Insert(OrderDetails orderDetails)
        {
            using var customContext = Context.CreateDbContext();
            customContext.OrderDetails.Add(orderDetails);
            customContext.SaveChanges();
        }
        public void Update(OrderDetails orderDetails)
        {

            using var customContext = Context.CreateDbContext();
            customContext.OrderDetails.Update(orderDetails);
            customContext.SaveChanges();
        }
        public void Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            customContext.OrderDetails.Remove(customContext.OrderDetails.Find(id));
            customContext.SaveChanges();
        }
    }
}
