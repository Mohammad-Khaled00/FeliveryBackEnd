using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IOrderWithDetails :IRepository<Order>
    {
        public void BothOrderOrderDetails(OrderOrderDetailsData Data);
    }
}
