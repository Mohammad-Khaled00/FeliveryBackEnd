using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class CustomerRepoService : BaseRepoService, IRepository<Customer>
    {
        public CustomerRepoService(IDbContextFactory<ElDbContext> context) : base(context)
    {

    }
        public List<Customer> GetAll()

        {
            List<Customer> CustomersList = new List<Customer>();

            using (var customContext = Context.CreateDbContext())
            {
                CustomersList = customContext.Customers.ToList();
            }
            return CustomersList;
        }
        public Customer GetDetails(int id)
        {

            using (var customContext = Context.CreateDbContext())
            {
                return customContext.Customers.Find(id);
            }
        }
        public void Insert(Customer t)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Customers.Add(t);
                customContext.SaveChanges();
            }
        }

        public void Update(Customer customer)
        {

            using (var customContext = Context.CreateDbContext())
            {
                customContext.Customers.Update(customer);
                customContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Customers.Remove(customContext.Customers.Find(id));
                customContext.SaveChanges();
            }
        }

    
    }
}
