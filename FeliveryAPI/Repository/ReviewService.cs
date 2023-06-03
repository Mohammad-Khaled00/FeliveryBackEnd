using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public class ReviewService : IFeedBackSercivce<Review>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetBycustomerID(int customerID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetBystoreID(int storeID)
        {
            throw new NotImplementedException();
        }

        public Review? GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Review t)
        {
            throw new NotImplementedException();
        }
    }
}
