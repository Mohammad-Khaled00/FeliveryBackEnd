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

            var OrderDet= new Order();
            using (var customContext = Context.CreateDbContext())
            {
                OrderDet = customContext.Orders.Find(id);
            }
            using (var customContext = Context.CreateDbContext())
            {

                OrderDet.Restaurant = customContext.Restaurants.First(r => r.Id == OrderDet.RestaurantID);
                OrderDet.Customer = customContext.Customers.First(r => r.Id == OrderDet.CustomerID);

            }
            return OrderDet;

        }
        public void Insert(Order order)
        {
            using var customContext = Context.CreateDbContext();
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
