using FeliveryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace FeliveryAPI.Data
{
    public class ElDbContext : IdentityDbContext
    {

        public ElDbContext(DbContextOptions<ElDbContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<TechnicalFeedBack> TechnicalFeedBack { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            builder.Entity<OrderDetails>().HasKey(vf => new { vf.OrderId, vf.MenuItemID });
        }
        private void SeedRoles(ModelBuilder Builder)
        {
            Builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                    new IdentityRole() { Name = "ApprovedStore", ConcurrencyStamp = "2", NormalizedName = "ApprovedStore" },
                    new IdentityRole() { Name = "PendingStore", ConcurrencyStamp = "3", NormalizedName = "PendingStore" },
                    new IdentityRole() { Name = "Customer", ConcurrencyStamp = "4", NormalizedName = "Customer" }
                );
        }
    }
}
