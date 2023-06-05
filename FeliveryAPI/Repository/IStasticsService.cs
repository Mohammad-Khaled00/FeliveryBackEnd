using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IStatisticsService
    {
        public Task<IEnumerable<Order>> GetOrdersBystoreID(int storeID);
        public Task<IEnumerable<Order>> GetFinshedOrdersBystoreID(int storeID);
        public Task<IEnumerable<Category>> GetCategoriesBystoreID(int storeID);
        public Task<IEnumerable<MenuItem>> GetmenuitemsBystoreID(int storeID);
        public Task<IEnumerable<MenuItem>> GetOffersBystoreID(int storeID);
        public Task<int> TotalEarnings(int storeID);
        public Task<int> TotalPendingOrders(int storeID);
        public Task<int> TotalDeliveredOrders(int storeID);
        public void DoneOrder(int orderID);
        public void SetRate(int rate, int storeId);
    }
}
