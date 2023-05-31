using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class OrderService : BaseRepoService, IRepository<Order>
    {
        public OrderService(IDbContextFactory<ElDbContext> context) : base(context)
        {
        }
        public List<Order> GetAll()
        {
            List<Order> OrdersList = new();

            using (var customContext = Context.CreateDbContext())
            {
                OrdersList = customContext.Orders.ToList();
            }
            return OrdersList;
        }
        public Order? GetDetails(int id)
        {
            using var customContext = Context.CreateDbContext();
            var DetailsList = customContext.OrderDetails.Where(o => o.OrderId == id).ToList();
            var order = customContext.Orders.Find(id);
            foreach (var Detail in DetailsList)
            {
                order.Details.Add(Detail);
            }
            return order;
        }
        public void Insert(Order order)
        {
            using var customContext = Context.CreateDbContext();
            order.Status = false;
            customContext.Orders.Add(order);
            customContext.SaveChanges();
        }
        public void Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Orders.Remove(customContext.Orders.Find(id));
            customContext.SaveChanges();
        }

        public void Update(Order order)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Orders.Update(order);
            customContext.SaveChanges();
        }
    }
}
