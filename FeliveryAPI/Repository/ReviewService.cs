using FeliveryAPI.Data;
using FeliveryAPI.Migrations;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class ReviewService : IFeedBackSercivce<Review>
    {
        public IDbContextFactory<ElDbContext> Context { get; }

        public ReviewService(IDbContextFactory<ElDbContext> context)
        {
            Context = context;
        }

        public List<Review> GetAll()
        {
            using var customContext = Context.CreateDbContext();
            List<Review> FeedBackList = customContext.Review.ToList();
            return FeedBackList;
        }
        public Review? GetDetails(int id)
        {
            using var customContext = Context.CreateDbContext();
            Review FeedBackDetails = customContext.Review.Find(id);
            return FeedBackDetails;
        }

        public async Task<IEnumerable<Review>> GetBycustomerID(int customerID)
        {
            List<Review> Feedback;
            using (var customContext = Context.CreateDbContext())
            {
                Feedback = await customContext.Review.Where(m => m.CustomerID == customerID).ToListAsync();
            }
            return Feedback;
        }

        public async Task<IEnumerable<Review>> GetBystoreID(int storeID)
        {
            List<Review> Feedback;
            using (var customContext = Context.CreateDbContext())
            {
                Feedback = await customContext.Review.Where(m => m.RestaurantID == storeID).ToListAsync();
            }
            return Feedback;
        }

        public void Insert(Review Feedback)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Review.Add(Feedback);
            customContext.SaveChanges();
        }

        public Review Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            if (customContext.Review.Find(id) != null)
            {
                Review Feedback = customContext.Review.Find(id);
                customContext.Review.Remove(Feedback);
                customContext.SaveChanges();
                return Feedback;
            }
            else
            {
                throw new Exception("Feedback Not Found");
            }
        }
    }
}
