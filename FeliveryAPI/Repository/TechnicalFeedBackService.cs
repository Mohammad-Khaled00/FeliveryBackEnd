using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class TechnicalFeedBackService : IFeedBackSercivce<TechnicalFeedBack>
    {
        public IDbContextFactory<ElDbContext> Context { get; }

        public TechnicalFeedBackService(IDbContextFactory<ElDbContext> context)
        {
            Context = context;
        }
        public List<TechnicalFeedBack> GetAll()
        {
            using var customContext = Context.CreateDbContext();
            List<TechnicalFeedBack> FeedBackList = customContext.TechnicalFeedBack.ToList();
            return FeedBackList;
        }

        public TechnicalFeedBack? GetDetails(int id)
        {
            using var customContext = Context.CreateDbContext();
            TechnicalFeedBack FeedBackDetails = customContext.TechnicalFeedBack.Find(id);
            return FeedBackDetails;
        }

        public async Task<IEnumerable<TechnicalFeedBack>> GetBycustomerID(int customerID)
        {
            List<TechnicalFeedBack> TechnicalFeedbacks;
            using (var customContext = Context.CreateDbContext())
            {
                TechnicalFeedbacks = await customContext.TechnicalFeedBack.Where(m => m.CustomerID == customerID).ToListAsync();
            }
            return TechnicalFeedbacks;
        }

        public async Task<IEnumerable<TechnicalFeedBack>> GetBystoreID(int storeID)
        {
            List<TechnicalFeedBack> TechnicalFeedbacks;
            using (var customContext = Context.CreateDbContext())
            {
                TechnicalFeedbacks = await customContext.TechnicalFeedBack.Where(m => m.RestaurantID == storeID).ToListAsync();
            }
            return TechnicalFeedbacks;
        }

        public void Insert(TechnicalFeedBack Feedback)
        {
            using var customContext = Context.CreateDbContext();
            customContext.TechnicalFeedBack.Add(Feedback);
            customContext.SaveChanges();
        }
        public TechnicalFeedBack Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            if (customContext.TechnicalFeedBack.Find(id) != null)
            {
                TechnicalFeedBack Feedback = customContext.TechnicalFeedBack.Find(id);
                customContext.TechnicalFeedBack.Remove(Feedback);
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
