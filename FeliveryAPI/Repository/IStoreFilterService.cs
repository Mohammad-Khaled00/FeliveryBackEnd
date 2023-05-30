using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IStoreFilterService
    {
        Task<IEnumerable<Order>> GetOrdersBystoreID(int storeID);
        Task<IEnumerable<Category>> GetCategoriesBystoreID(int storeID);
        Task<IEnumerable<MenuItem>> GetmenuitemsBystoreID(int storeID);
    }
}
