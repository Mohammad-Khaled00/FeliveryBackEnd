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
            using (var customContext = Context.CreateDbContext())
            {
                foreach (var order in OrdersList)
                {
                    order.Restaurant = customContext.Restaurants.First(r => r.Id == order.RestaurantID);
                    order.Customer = customContext.Customers.First(r => r.Id == order.CustomerID);
                }
            }
            return OrdersList;
        }

        public Order? GetDetails(int id)
        {
            using var customContext = Context.CreateDbContext();
            var DetailsList = customContext.OrderDetails.Where(o => o.OrderId == id).ToList();
            Order order = customContext.Orders.Find(id);
            foreach (var Detail in DetailsList)
            {
                //var x = customContext.MenuItems.Where(m => m.Id == Detail.MenuItemID).Select(m => m.Name).First();
                Detail.MenuItem = customContext.MenuItems.Where(m => m.Id == Detail.MenuItemID).First();
                order.Details.Add(Detail);
            }
                order.Restaurant = customContext.Restaurants.First(r => r.Id == order.RestaurantID);
                order.Customer = customContext.Customers.First(r => r.Id == order.CustomerID);
                return order;
        }

        public void Insert(Order order)
        {
            using var customContext = Context.CreateDbContext();
            order.Status = false;
            customContext.Orders.Add(order);
            customContext.SaveChanges();
        }

        public Order Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            Order OrderData = customContext.Orders.Find(id);
            customContext.Orders.Remove(OrderData);
            customContext.SaveChanges();
            return OrderData;
        }

        public void Update(Order order)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Orders.Update(order);
            customContext.SaveChanges();
        }
    }
}
