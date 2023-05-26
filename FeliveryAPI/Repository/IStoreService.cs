using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IStoreService : IRepository<Restaurant> , IUserService
    {
        Task<AuthModel> Register(RegData mix);

    }
}
