using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IStoreService : IRepository<Restaurant> , IUserService
    {
        Task<AuthModel> Register(RegData Data);
        Task<IEnumerable<Restaurant>> Search(string Name);
        public List<Restaurant> PendingStore();

    }
}
