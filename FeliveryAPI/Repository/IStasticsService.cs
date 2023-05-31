using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IStatisticsService
    {
        public Task<IEnumerable<Order>> GetOrdersBystoreID(int storeID);
        public Task<IEnumerable<Category>> GetCategoriesBystoreID(int storeID);
        public Task<IEnumerable<MenuItem>> GetmenuitemsBystoreID(int storeID);
        public Task<int> TotalEarnings(int storeID);
        public Task<int> PendingOrders(int storeID);
        public Task<int> DeliveredOrders(int storeID);
        public void DoneOrder(int orderID);
    }
}
