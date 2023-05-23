using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace FeliveryAPI.Data
{
    public class ElDbContext : DbContext
    {
        public ElDbContext(DbContextOptions<ElDbContext> options) : base(options)
        {
        }
              public DbSet<Restaurant> Restaurants { get; set; }
              public DbSet<Category> Categories { get; set; }
              public DbSet<MenuItem> MenuItems { get; set; }
              public DbSet<Order> Orders { get; set; }
              public DbSet<Customer> Customers { get; set; }
              public DbSet<Offer> Offers { get; set; }


    }
}
