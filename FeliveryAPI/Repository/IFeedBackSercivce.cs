using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IFeedBackSercivce<T>
    {
        public List<T> GetAll();
        public T? GetDetails(int id);
        public Task<IEnumerable<T>> GetBystoreID(int storeID);
        public Task<IEnumerable<T>> GetBycustomerID(int customerID);
        public void Insert(T t);
        public void Delete(int id);
    }
}

