using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace FeliveryAPI.Repository
{
    public class OrderDetailsService :BaseRepoService 
    {
        public OrderDetailsService(IDbContextFactory<ElDbContext> context) : base(context)
        {
        }
        public List<OrderDetails> GetAll()

        {
            List<OrderDetails> CategoriesList = new List<OrderDetails>();

            using (var customContext = Context.CreateDbContext())
            {
                CategoriesList = customContext.OrderDetails.ToList();
            }
            return CategoriesList;
        }

        public OrderDetails GetDetails(int id)
        {


            using (var customContext = Context.CreateDbContext())
            {
                return customContext.OrderDetails.Find(id);
            }
        }
        public void Insert(OrderDetails orderDetails)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.OrderDetails.Add(orderDetails);
                customContext.SaveChanges();
            }
        }
        //public void InsertOrder(Order order)
        //{
        //    using (var customContext = Context.CreateDbContext())
        //    {
        //        customContext.Orders.Add(order);
        //        customContext.SaveChanges();
        //    }
        //}

        //public void BothOrderOrderDetails(OrderOrderDetailsData Data)
        //{
        //    using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
        //    try
        //    {
        //        TransactionManager.ImplicitDistributedTransactions = true;
        //        TransactionInterop.GetTransmitterPropagationToken(Transaction.Current);
        //        InsertOrder(Data.order);
        //        Insert(Data.orderDetailes);
        //        transaction.Complete();

        //    }
        //    catch (Exception ex) { }

         
        //}

        ///////////////////////////////////////////////////////
        public void Update(OrderDetails orderDetails)
        {

            using (var customContext = Context.CreateDbContext())
            {
                customContext.OrderDetails.Update(orderDetails);
                customContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.OrderDetails.Remove(customContext.OrderDetails.Find(id));
                customContext.SaveChanges();
            }
        }      
    }
    //public class OrderOrderDetailsData
    //{
    //    public Order order { get; set; }
    //    public OrderDetails orderDetailes { get; set; }
    //}
}
