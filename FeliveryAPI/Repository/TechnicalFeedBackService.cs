using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public class TechnicalFeedBackService : IFeedBackSercivce<TechnicalFeedBack>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TechnicalFeedBack> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TechnicalFeedBack>> GetBycustomerID(int customerID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TechnicalFeedBack>> GetBystoreID(int storeID)
        {
            throw new NotImplementedException();
        }

        public TechnicalFeedBack? GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TechnicalFeedBack t)
        {
            throw new NotImplementedException();
        }
    }
}
