using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace FeliveryAPI.Repository
{
    public class OrderRepoService : BaseRepoService, IOrderWithDetails
    {
        public OrderRepoService(IDbContextFactory<ElDbContext> context) : base(context)
        {
        }
        public List<Order> GetAll()
        {
            List<Order> OrdersList = new List<Order>();

            using (var customContext = Context.CreateDbContext())
            {
                OrdersList = customContext.Orders.ToList();
            }
            return OrdersList;
        }
        public Order? GetDetails(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                return customContext.Orders.Find(id);
            }
        }
        public void Insert(Order order)
        {

            using (var customContext = Context.CreateDbContext())
            {
                customContext.Orders.Add(order);
                customContext.SaveChanges();
            }
            
        }
        public void Delete(int id)
        {

            using (var customContext = Context.CreateDbContext())
            {
                customContext.Orders.Remove(customContext.Orders.Find(id));
                customContext.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Orders.Update(order);
                customContext.SaveChanges();
            }
        }
        public void InsertOrderDetails(OrderDetails orderDetails)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.OrderDetails.Add(orderDetails);
                customContext.SaveChanges();
            }
        }

        public void BothOrderOrderDetails(OrderOrderDetailsData Data)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                TransactionManager.ImplicitDistributedTransactions = true;
                TransactionInterop.GetTransmitterPropagationToken(Transaction.Current);
                InsertOrderDetails(Data.orderDetailes);
                Insert(Data.order);
                transaction.Complete();

            }
            catch (Exception ex) { }
        }
    }
    public class OrderOrderDetailsData
    {
        public Order order { get; set; }
        public OrderDetails orderDetailes { get; set; }
    }
}
